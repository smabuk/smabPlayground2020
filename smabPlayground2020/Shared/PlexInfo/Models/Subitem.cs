using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace smabPlayground2020.Shared.PlexInfo.Models
{
    public class Subitem
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("filter")]
        public string? Filter { get; set; }

        [JsonPropertyName("tag")]
        public string Tag { get; set; }

    }
}
