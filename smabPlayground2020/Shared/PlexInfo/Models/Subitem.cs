using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace smab.PlexInfo.Models
{
	public record Subitem
    {
        [JsonPropertyName("id")]
        public int? Id { get; init; }

        [JsonPropertyName("filter")]
        public string? Filter { get; init; }

        [JsonPropertyName("tag")]
        public string Tag { get; init; }

		public override string ToString() => Tag;

    }
}
