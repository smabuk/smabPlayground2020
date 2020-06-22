using System.Text.Json.Serialization;

namespace smabPlayground2020.Shared.PlexInfo.Models
{
	public class Location
    {

        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("path")]
        public string Path { get; set; } = "";
    }

}
