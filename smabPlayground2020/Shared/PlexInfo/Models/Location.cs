using System.Text.Json.Serialization;

namespace smab.PlexInfo.Models
{
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    public class Location
    {

        [JsonPropertyName("id")]
        public int? Id { get; init; }

        [JsonPropertyName("path")]
        public string Path { get; init; }
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

}
