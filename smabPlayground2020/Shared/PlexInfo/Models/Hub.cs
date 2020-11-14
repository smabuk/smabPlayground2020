using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace smab.PlexInfo.Models
{
	public record Hub
    {
        [JsonPropertyName("hubkey")]
        public string HubKey { get; init; }

        [JsonPropertyName("key")]
        public string Key { get; init; }

        [JsonPropertyName("title")]
        public string Title { get; init; }

        [JsonPropertyName("type")]
        public string Type { get; init; }

        [JsonPropertyName("hubIdentifier")]
        public string HubIdentifier { get; init; }

        [JsonPropertyName("context")]
        public string Context { get; init; }

        [JsonPropertyName("size")]
        public int Size { get; init; }

        [JsonPropertyName("more")]
        public bool More { get; init; }

        [JsonPropertyName("style")]
        public string Style { get; init; }

        [JsonPropertyName("Metadata")]
        public List<Metadata>? MetaData { get; init; }
    }
}
