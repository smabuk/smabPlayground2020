using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace smabPlayground2020.Shared.PlexInfo.Models
{
    public class Hub
    {
        [JsonPropertyName("hubkey")]
        public string HubKey { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("hubIdentifier")]
        public string HubIdentifier { get; set; }

        [JsonPropertyName("context")]
        public string Context { get; set; }

        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("more")]
        public bool More { get; set; }

        [JsonPropertyName("style")]
        public string Style { get; set; }

        [JsonPropertyName("Metadata")]
        public IEnumerable<Metadata>? MetaData { get; set; }
    }
}
