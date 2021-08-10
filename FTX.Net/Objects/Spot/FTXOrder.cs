﻿using FTX.Net.Converters;
using FTX.Net.Enums;
using Newtonsoft.Json;
using System;

namespace FTX.Net.Objects
{
    /// <summary>
    /// Order info
    /// </summary>
    public class FTXOrder
    {
        /// <summary>
        /// Id of the order
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// When the order was created
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// The quantity that is filled
        /// </summary>
        [JsonProperty("filledSize")]
        public decimal FilledQuantity { get; set; }
        /// <summary>
        /// The future the order is for
        /// </summary>
        public string Future { get; set; } = string.Empty;
        /// <summary>
        /// The market to order is for
        /// </summary>
        public string Market { get; set; } = string.Empty;
        /// <summary>
        /// The price of the order
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// The remaining quantity
        /// </summary>
        [JsonProperty("remainingSize")]
        public decimal RemainingQuantity { get; set; }
        /// <summary>
        /// The side
        /// </summary>
        [JsonConverter(typeof(OrderSideConverter))]
        public OrderSide Side { get; set; }
        /// <summary>
        /// The order type
        /// </summary>
        [JsonConverter(typeof(OrderTypeConverter))]
        public OrderType Type { get; set; }
        /// <summary>
        /// The total quantity of the order
        /// </summary>
        [JsonProperty("size")]
        public decimal Quantity { get; set; }
        /// <summary>
        /// The status of the order
        /// </summary>
        [JsonConverter(typeof(OrderStatusConverter))]
        public OrderStatus Status { get; set; }
        /// <summary>
        /// Reduce only order
        /// </summary>
        public bool ReduceOnly { get; set; }
        /// <summary>
        /// Immediate or cancel order
        /// </summary>
        [JsonProperty("ioc")]
        public bool ImmediateOrCancel { get; set; }
        /// <summary>
        /// Post only order
        /// </summary>
        public bool PostOnly { get; set; }
        /// <summary>
        /// Client id
        /// </summary>
        public string? ClientId { get; set; }
        /// <summary>
        /// Average execution price
        /// </summary>
        [JsonProperty("avgFillPrice")]
        public decimal? AverageFillPrice { get; set; }
    }
}