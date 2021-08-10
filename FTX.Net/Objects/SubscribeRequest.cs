﻿using Newtonsoft.Json;

namespace FTX.Net.Objects.SocketObjects
{
    public class SubscribeRequest: SocketRequest
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("market")]
        public string Market { get; set; }

        public SubscribeRequest(string channel, string symbol): base("subscribe")
        {
            Channel = channel;
            Market = symbol;
        }
    }
}