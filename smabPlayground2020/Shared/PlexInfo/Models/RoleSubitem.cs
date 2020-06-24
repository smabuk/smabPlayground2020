using System.Text.Json.Serialization;

namespace smabPlayground2020.Shared.PlexInfo.Models
{
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    public class RoleSubitem : Subitem
    {
        [JsonPropertyName("role")]
        public string? Role { get; set; }

        [JsonPropertyName("thumb")]
        public string? Thumb { get; set; }

    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

}
