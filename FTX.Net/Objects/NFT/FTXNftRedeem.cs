﻿using FTX.Net.Converters;
using FTX.Net.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FTX.Net.Objects.NFT
{
    /// <summary>
    /// Redeem id
    /// </summary>
    public class FTXNftRedeem
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// NFT details
        /// </summary>
        public FTXNft Nft { get; set; } = default!;
        /// <summary>
        /// Timstamp
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// Notes
        /// </summary>
        public string? Notes { get; set; }
        /// <summary>
        /// Address
        /// </summary>
        public string Address { get; set; } = string.Empty;
        /// <summary>
        /// Status
        /// </summary>
        [JsonConverter(typeof(NFTRedeemStatusConverter))]
        public NFTRedeemStatus Status { get; set; }
        /// <summary>
        /// Support ticket id
        /// </summary>
        public long? SupportTicketId { get; set; }
    }
}
