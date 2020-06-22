using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace smabPlayground2020.Shared.PlexInfo.Models
{
	public class Medium
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("duration")]
		public int Duration { get; set; }

		[JsonPropertyName("bitrate")]
		public int Bitrate { get; set; }

		[JsonPropertyName("width")]
		public int Width { get; set; }

		[JsonPropertyName("height")]
		public int Height { get; set; }

		[JsonPropertyName("aspectRatio")]
		public float AspectRatio { get; set; }

		[JsonPropertyName("audioChannels")]
		public int AudioChannels { get; set; }

		[JsonPropertyName("audioCodec")]
		public string AudioCodec { get; set; }

		[JsonPropertyName("videoCodec")]
		public string VideoCodec { get; set; }

		[JsonPropertyName("videoResolution")]
		public string VideoResolution { get; set; }

		[JsonPropertyName("container")]
		public string Container { get; set; }

		[JsonPropertyName("videoFrameRate")]
		public string VideoFrameRate { get; set; }

		[JsonPropertyName("videoProfile")]
		public string VideoProfile { get; set; }

		[JsonPropertyName("Part")]
		public IEnumerable<Part>? Part { get; set; }

		[JsonPropertyName("optimizedForStreaming")]
		public int OptimizedForStreaming { get; set; }

		[JsonPropertyName("audioProfile")]
		public string AudioProfile { get; set; }

		[JsonPropertyName("has64bitOffsets")]
		public bool Has64bitOffsets { get; set; }
	}

}
