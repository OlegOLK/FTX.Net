﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FTX.Net.Objects.Subaccounts
{
    /// <summary>
    /// Subaccount transfer
    /// </summary>
    public class FTXSubaccountTransfer
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Asset transfered
        /// </summary>
        public string Asset { get; set; } = string.Empty;
        /// <summary>
        /// Quantity transfered
        /// </summary>
        public decimal Quantity { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// Notes
        /// </summary>
        public string? Notes { get; set; }
        /// <summary>
        /// Status; always `completed`
        /// </summary>
        public string Status { get; set; } = string.Empty;
    }
}
