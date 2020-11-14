using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace smab.PlexInfo.Models
{
	public record Stream
	{
        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("streamType")]
        public int StreamType { get; init; }

        [JsonPropertyName("codec")]
        public string Codec { get; init; }

        [JsonPropertyName("index")]
        public int Index { get; init; }

        [JsonPropertyName("bitrate")]
        public int Bitrate { get; init; }

        [JsonPropertyName("bitDepth")]
        public int BitDepth { get; init; }

        [JsonPropertyName("chromaLocation")]
        public string ChromaLocation { get; init; }

        [JsonPropertyName("chromaSubsampling")]
        public string ChromaSubsampling { get; init; }

        [JsonPropertyName("codedHeight")]
        public int CodedHeight { get; init; }

        [JsonPropertyName("codedWidth")]
        public int CodedWidth { get; init; }

        [JsonPropertyName("frameRate")]
        public double FrameRate { get; init; }

        [JsonPropertyName("height")]
        public int Height { get; init; }

        [JsonPropertyName("level")]
        public int Level { get; init; }

        [JsonPropertyName("profile")]
        public string Profile { get; init; }

        [JsonPropertyName("refFrames")]
        public int RefFrames { get; init; }

        [JsonPropertyName("width")]
        public int Width { get; init; }

        [JsonPropertyName("displayTitle")]
        public string DisplayTitle { get; init; }

        [JsonPropertyName("selected")]
        public bool? Selected { get; init; }

        [JsonPropertyName("channels")]
        public int? Channels { get; init; }

        [JsonPropertyName("audioChannelLayout")]
        public string AudioChannelLayout { get; init; }

        [JsonPropertyName("samplingRate")]
        public int? SamplingRate { get; init; }

        [JsonPropertyName("streamIdentifier")]
        public string StreamIdentifier { get; init; }
    }
}
