using System.Text.Json.Serialization;

namespace smab.PlexInfo.Models
{
	public record RoleSubitem : Subitem
    {
        [JsonPropertyName("role")]
        public string? Role { get; init; }

        [JsonPropertyName("thumb")]
        public string? Thumb { get; init; }

    }
}
