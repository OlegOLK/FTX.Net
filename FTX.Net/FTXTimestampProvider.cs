﻿using CryptoExchange.Net.Logging;
using FTX.Net.Interfaces;
using FTX.Net.Objects;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FTX.Net
{
    internal static class FTXTimestampProvider
    {
        internal static double CalculatedTimeOffset;
        internal static DateTime LastSync;

        private static SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        internal static async Task UpdateTimeAsync(FTXClient client, Log log, FTXClientOptions options)
        {
            if (await _semaphore.WaitAsync(0).ConfigureAwait(false))
            {
                if (!options.AutoTimestamp || (DateTime.UtcNow - LastSync < options.AutoTimestampRecalculationInterval))
                {
                    _semaphore.Release();
                    return;
                }

                var localTime = DateTime.UtcNow;
                var result = await client.GetServerTimeAsync().ConfigureAwait(false);
                if (!result)
                {
                    _semaphore.Release();
                    return;
                }

                if (client.TotalRequestsMade == 1)
                {
                    // If this was the first request make another one to calculate the offset since the first one can be slower
                    localTime = DateTime.UtcNow;
                    result = await client.GetServerTimeAsync().ConfigureAwait(false);
                    if (!result)
                    {
                        _semaphore.Release();
                        return;
                    }
                }

                // Calculate time offset between local and server
                var offset = (result.Data - localTime).TotalMilliseconds;
                if (offset >= 0 && offset < 500)
                {
                    // Small offset, probably mainly due to ping. Don't adjust time
                    CalculatedTimeOffset = 0;
                    LastSync = DateTime.UtcNow;
                    log.Write(LogLevel.Information, $"Time offset between 0 and 500ms ({offset}ms), no adjustment needed");
                    _semaphore.Release();
                }
                else
                {
                    CalculatedTimeOffset = (result.Data - localTime).TotalMilliseconds;
                    LastSync = DateTime.UtcNow;
                    log.Write(LogLevel.Information, $"Time offset set to {CalculatedTimeOffset}ms");
                    _semaphore.Release();
                }
            }
        }

        internal static string GetTimestamp()
        {
            return ToUnixTimestamp(DateTime.UtcNow.AddMilliseconds(CalculatedTimeOffset)).ToString(CultureInfo.InvariantCulture);
        }

        private static long ToUnixTimestamp(DateTime time)
        {
            return (long)(time - new DateTime(1970, 1, 1)).TotalMilliseconds;
        }
    }
}
