using System.Text.Json.Serialization;

namespace smab.PlexInfo.Models
{
	public record Location
    {
        [JsonPropertyName("id")]
        public int? Id { get; init; }

        [JsonPropertyName("path")]
        public string Path { get; init; }
    }
}
