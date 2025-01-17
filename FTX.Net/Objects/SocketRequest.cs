﻿using Newtonsoft.Json;

namespace FTX.Net.Objects.SocketObjects
{
    internal class SocketRequest
    {
        [JsonProperty("op")]
        public string Operation { get; set; }

        public SocketRequest(string operation)
        {
            Operation = operation;
        }
    }
}
