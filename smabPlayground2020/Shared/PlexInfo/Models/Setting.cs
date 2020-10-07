using System.Text.Json;
using System.Text.Json.Serialization;

namespace smab.PlexInfo.Models
{
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    public class Setting
    {
        [JsonPropertyName("id")]
        public string Id { get; init; }

        [JsonPropertyName("label")]
        public string Label { get; init; }

        [JsonPropertyName("summary")]
        public string Summary { get; init; }

        [JsonPropertyName("type")]
        public string Type { get; init; }

        [JsonPropertyName("default")]
        public object Default { get; init; }

        [JsonPropertyName("value")]
        public object Value { get; init; }

        [JsonPropertyName("hidden")]
        public bool Hidden { get; init; }

        [JsonPropertyName("advanced")]
        public bool Advanced { get; init; }

        [JsonPropertyName("group")]
        public string Group { get; init; }

    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
}
