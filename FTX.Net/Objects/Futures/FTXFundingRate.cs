﻿using Newtonsoft.Json;
using System;

namespace FTX.Net.Objects.Futures
{
    /// <summary>
    /// Funding rate info
    /// </summary>
    public class FTXFundingRate
    {
        /// <summary>
        /// Future name
        /// </summary>
        public string Future { get; set; } = string.Empty;
        /// <summary>
        /// Funding rate
        /// </summary>
        public decimal Rate { get; set; }
        /// <summary>
        /// Time
        /// </summary>
        [JsonProperty("time")]
        public DateTime Timestamp { get; set; }
    }
}
