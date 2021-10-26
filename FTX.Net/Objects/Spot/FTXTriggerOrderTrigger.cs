﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FTX.Net.Objects.Spot
{
    /// <summary>
    /// Trigger info
    /// </summary>
    public class FTXTriggerOrderTrigger
    {
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonProperty("time")]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Quantity of the order
        /// </summary>
        [JsonProperty("orderSize")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// Filled order
        /// </summary>
        [JsonProperty("filledSize")]
        public decimal QuantityFilled { get; set; }
        /// <summary>
        /// Order id, null if failed to place
        /// </summary>
        public long? OrderId { get; set; }
        /// <summary>
        /// Error if order failed
        /// </summary>
        public string? Error { get; set; }
    }
}
