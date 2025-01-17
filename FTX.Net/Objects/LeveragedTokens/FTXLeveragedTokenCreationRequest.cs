﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FTX.Net.Objects.LeveragedTokens
{
    /// <summary>
    /// Leveraged token creation request
    /// </summary>
    public class FTXLeveragedTokenCreationRequest
    {
        /// <summary>
        /// Id of the request
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Token name
        /// </summary>
        public string Token { get; set; } = string.Empty;
        /// <summary>
        /// Number of tokens originally requested
        /// </summary>
        public int RequestedSize { get; set; }
        /// <summary>
        /// Is pending
        /// </summary>
        public bool Pending { get; set; }
        /// <summary>
        /// Number of tokens created; may be less than the requested number
        /// </summary>
        public int? CreatedSize { get; set; }
        /// <summary>
        /// Price at which the creation request was fulfilled
        /// </summary>
        public decimal? Price { get; set; }
        /// <summary>
        /// Cost of creating the tokens, not including fees
        /// </summary>
        public decimal Cost { get; set; }
        /// <summary>
        /// Fee for creating the tokens
        /// </summary>
        public decimal? Fee { get; set; }
        /// <summary>
        /// Time the request was submitted
        /// </summary>
        public DateTime RequestedAt { get; set; }
        /// <summary>
        /// Time the request was processed
        /// </summary>
        public DateTime? FullFilledAt { get; set; }
    }
}
