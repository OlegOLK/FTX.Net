﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FTX.Net.Enums
{
    /// <summary>
    /// Withdraw status
    /// </summary>
    public enum NFTWithdrawalStatus
    {
        /// <summary>
        /// Requested
        /// </summary>
        Requested,
        /// <summary>
        /// Processing
        /// </summary>
        Processing,
        /// <summary>
        /// Sent
        /// </summary>
        Sent,
        /// <summary>
        /// Completed
        /// </summary>
        Completed,
        /// <summary>
        /// Cancelled
        /// </summary>
        Cancelled
    }
}
