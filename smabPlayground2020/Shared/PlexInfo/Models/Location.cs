using System.Text.Json.Serialization;

namespace smabPlayground2020.Shared.PlexInfo.Models
{
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    public class Location
    {

        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("path")]
        public string Path { get; set; }
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

}
