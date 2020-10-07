using System.Text.Json.Serialization;

namespace smab.PlexInfo.Models
{
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    public class RoleSubitem : Subitem
    {
        [JsonPropertyName("role")]
        public string? Role { get; init; }

        [JsonPropertyName("thumb")]
        public string? Thumb { get; init; }

    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

}
