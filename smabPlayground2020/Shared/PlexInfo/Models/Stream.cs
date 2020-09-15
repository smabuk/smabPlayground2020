using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace smabPlayground2020.Shared.PlexInfo.Models
{
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    public class Stream
	{
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("streamType")]
        public int StreamType { get; set; }

        [JsonPropertyName("codec")]
        public string Codec { get; set; }

        [JsonPropertyName("index")]
        public int Index { get; set; }

        [JsonPropertyName("bitrate")]
        public int Bitrate { get; set; }

        [JsonPropertyName("bitDepth")]
        public int BitDepth { get; set; }

        [JsonPropertyName("chromaLocation")]
        public string ChromaLocation { get; set; }

        [JsonPropertyName("chromaSubsampling")]
        public string ChromaSubsampling { get; set; }

        [JsonPropertyName("codedHeight")]
        public int CodedHeight { get; set; }

        [JsonPropertyName("codedWidth")]
        public int CodedWidth { get; set; }

        [JsonPropertyName("frameRate")]
        public double FrameRate { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("level")]
        public int Level { get; set; }

        [JsonPropertyName("profile")]
        public string Profile { get; set; }

        [JsonPropertyName("refFrames")]
        public int RefFrames { get; set; }

        [JsonPropertyName("width")]
        public int Width { get; set; }

        [JsonPropertyName("displayTitle")]
        public string DisplayTitle { get; set; }

        [JsonPropertyName("selected")]
        public bool? Selected { get; set; }

        [JsonPropertyName("channels")]
        public int? Channels { get; set; }

        [JsonPropertyName("audioChannelLayout")]
        public string AudioChannelLayout { get; set; }

        [JsonPropertyName("samplingRate")]
        public int? SamplingRate { get; set; }

        [JsonPropertyName("streamIdentifier")]
        public string StreamIdentifier { get; set; }
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

}
