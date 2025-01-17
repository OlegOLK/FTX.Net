﻿using FTX.Net.Converters;
using FTX.Net.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;


namespace FTX.Net.Objects.Spot
{
    /// <summary>
    /// Trigger order info
    /// </summary>
    public class FTXTriggerOrder: FTXOrderBase
    {
        /// <summary>
        /// The order type
        /// </summary>
        [JsonConverter(typeof(OrderTypeConverter))]
        public override OrderType OrderType { get; set; }
        /// <summary>
        /// The price of the order
        /// </summary>
        public override decimal? OrderPrice { get; set; }

        /// <summary>
        /// Id of the order
        /// </summary>
        public long? OrderId { get; set; }
        /// <summary>
        /// The trigger price
        /// </summary>
        public decimal? TriggerPrice { get; set; }
        /// <summary>
        /// The trigger type
        /// </summary>
        [JsonConverter(typeof(TriggerOrderTypeConverter))]
        public TriggerOrderType Type { get; set; }
        /// <summary>
        /// Status of the trigger order
        /// </summary>
        [JsonConverter(typeof(TriggerOrderStatusConverter))]
        public TriggerOrderStatus Status { get; set; }
        /// <summary>
        /// Error message for order placing
        /// </summary>
        public string? Error { get; set; }
        /// <summary>
        /// Time at which the order was triggered
        /// </summary>
        public DateTime? TriggeredAt { get; set; }
        /// <summary>
        /// Whether or not to keep re-triggering until filled
        /// </summary>
        public bool RetryUntilFilled { get; set; }
        /// <summary>
        /// Trail start
        /// </summary>
        public decimal? TrailStart { get; set; }
        /// <summary>
        /// Trail start
        /// </summary>
        public decimal? TrailValue { get; set; }
        /// <summary>
        /// Time at which the order was cancelled
        /// </summary>
        public DateTime? CancelledAt { get; set; }
        /// <summary>
        /// Cancellation reason
        /// </summary>
        public string? CancelReason { get; set; }
    }
}
