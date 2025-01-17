﻿using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;

namespace FTX.Net
{
    internal class FTXAuthenticationProvider : AuthenticationProvider
    {
        private readonly HMACSHA256 _encryptor;

        public FTXAuthenticationProvider(ApiCredentials credentials) : base(credentials)
        {
            if (credentials.Secret == null)
                throw new ArgumentException("No valid API credentials provided. Key/Secret needed.");

            _encryptor = new HMACSHA256(Encoding.ASCII.GetBytes(credentials.Secret.GetString()));
        }

        public override Dictionary<string, string> AddAuthenticationToHeaders(string uri, HttpMethod method, Dictionary<string, object> parameters, bool signed, HttpMethodParameterPosition parameterPosition, ArrayParametersSerialization arraySerialization)
        {
            var result = new Dictionary<string, string>();
            if (!signed)
                return result;

            if (Credentials.Key == null)
                throw new ArgumentException("No valid API credentials provided. Key/Secret needed.");

            var requestUri = new Uri(uri);
            var ftxPrefix = GetFTXHeaderPrefix(requestUri);
            var timestamp = FTXTimestampProvider.GetTimestamp();

            result.Add($"{ftxPrefix}-KEY", Credentials.Key.GetString());
            result.Add($"{ftxPrefix}-TS", timestamp.ToString());

            var toSign = timestamp + method.ToString() + requestUri.PathAndQuery;
            if (parameterPosition == HttpMethodParameterPosition.InBody)
            {
                toSign += JsonConvert.SerializeObject(parameters.OrderBy(p => p.Key).ToDictionary(p => p.Key, p => p.Value));
            }

            result.Add($"{ftxPrefix}-SIGN", ByteToString(_encryptor.ComputeHash(Encoding.ASCII.GetBytes(toSign))).ToLowerInvariant());


            return result;
        }

        public override string Sign(string toSign)
        {
            return ByteToString(_encryptor.ComputeHash(Encoding.ASCII.GetBytes(toSign))).ToLowerInvariant();
        }

        private string GetFTXHeaderPrefix(Uri requestUri)
        {
            var headerKeyPrefix = "FTX";
            var isFtxUs = requestUri.Host.EndsWith(".us", StringComparison.OrdinalIgnoreCase);
            if (isFtxUs)
            {
                headerKeyPrefix += "US";
            }

            return headerKeyPrefix;
        }
    }
}
