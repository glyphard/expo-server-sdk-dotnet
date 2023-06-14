﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Expo.Server.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class PushTicketRequest
    {
        [JsonProperty(PropertyName = "to")]
        public List<string> PushTo { get; set; }

        [JsonProperty(PropertyName = "data")]
        public object PushData { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string PushTitle { get; set; }

        [JsonProperty(PropertyName = "body")]
        public string PushBody { get; set; }

        [JsonProperty(PropertyName = "ttl")]
        public int? PushTTL { get; set; }

        [JsonProperty(PropertyName = "expiration")]
        public int? PushExpiration { get; set; }

        [JsonProperty(PropertyName = "priority")]  //'default' | 'normal' | 'high'
        public string PushPriority { get; set; }

        [JsonProperty(PropertyName = "subtitle")]
        public string PushSubTitle { get; set; }

        [JsonProperty(PropertyName = "sound")] //'default' | null	
        public string PushSound { get; set; }

        [JsonProperty(PropertyName = "badge")]
        public int? PushBadgeCount { get; set; }

        [JsonProperty(PropertyName = "channelId")]
        public string PushChannelId { get; set; }

        [JsonProperty(PropertyName = "categoryId")]
        public string PushCategoryId { get; set; }

        [JsonProperty(PropertyName = "_contentAvailable")]
        public bool PushContentAvailable { get; set; }
    }
}
