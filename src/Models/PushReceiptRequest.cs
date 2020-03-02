using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace expo_server_sdk_dotnet.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class PushReceiptRequest
    {
        
        [JsonProperty(PropertyName ="ids")]
        public List<string> PushTicketIds { get; set; }
    }
}
