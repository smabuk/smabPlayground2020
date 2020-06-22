using System.Text.Json.Serialization;

namespace smabPlayground2020.Shared.PlexInfo.Models
{
	public class RoleSubitem : Subitem
    {
        [JsonPropertyName("role")]
        public string? Role { get; set; }

        [JsonPropertyName("thumb")]
        public string? Thumb { get; set; }

    }

}
