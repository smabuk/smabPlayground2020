using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace smabPlayground2020.Shared.PlexInfo.Models
{
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    public class Subitem
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("filter")]
        public string? Filter { get; set; }

        [JsonPropertyName("tag")]
        public string Tag { get; set; }

		public override string ToString() => Tag;

    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
}
