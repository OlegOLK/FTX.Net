﻿using FTX.Net.Converters;
using FTX.Net.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FTX.Net.Objects.Convert
{
    /// <summary>
    /// Convert quote
    /// </summary>
    public class FTXConvertQuote
    {
        /// <summary>
        /// From asset
        /// </summary>
        [JsonProperty("baseCoin")]
        public string BaseAsset { get; set; } = string.Empty;
        /// <summary>
        /// To asset
        /// </summary>
        [JsonProperty("fromCoin")]
        public string FromAsset { get; set; } = string.Empty;
        /// <summary>
        /// To asset
        /// </summary>
        [JsonProperty("quoteCoin")]
        public string QuoteAsset { get; set; } = string.Empty;
        /// <summary>
        /// To asset
        /// </summary>
        [JsonProperty("toCoin")]
        public string ToAsset { get; set; } = string.Empty;
        /// <summary>
        /// Cost of accepting the quote in units of fromCoin
        /// </summary>
        public decimal Cost { get; set; }
        /// <summary>
        /// If the quote is expired (if so, cannot accept it)
        /// </summary>
        public bool Expired { get; set; }
        /// <summary>
        /// If the quote is already accepted
        /// </summary>
        public decimal Filled { get; set; }
        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Price in units of quoteCoin
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Proceeds of accepting the quote in units of toCoin
        /// </summary>
        public decimal Proceeds { get; set; }
        /// <summary>
        /// "sell" if FromAsset is BaseAsset, otherwise "buy"
        /// </summary>
        [JsonConverter(typeof(OrderSideConverter))]
        public OrderSide Side { get; set; }
    }
}
