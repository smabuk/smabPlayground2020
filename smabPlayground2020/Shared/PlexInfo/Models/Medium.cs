using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace smab.PlexInfo.Models
{
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
	public class Medium
	{
		[JsonPropertyName("id")]
		public int Id { get; init; }

		[JsonPropertyName("duration")]
		public int Duration { get; init; }

		[JsonPropertyName("bitrate")]
		public int Bitrate { get; init; }

		[JsonPropertyName("width")]
		public int Width { get; init; }

		[JsonPropertyName("height")]
		public int Height { get; init; }

		[JsonPropertyName("aspectRatio")]
		public float AspectRatio { get; init; }

		[JsonPropertyName("audioChannels")]
		public int AudioChannels { get; init; }

		[JsonPropertyName("audioCodec")]
		public string AudioCodec { get; init; }

		[JsonPropertyName("videoCodec")]
		public string VideoCodec { get; init; }

		[JsonPropertyName("videoResolution")]
		public string VideoResolution { get; init; }

		[JsonPropertyName("container")]
		public string Container { get; init; }

		[JsonPropertyName("videoFrameRate")]
		public string VideoFrameRate { get; init; }

		[JsonPropertyName("videoProfile")]
		public string VideoProfile { get; init; }

		[JsonPropertyName("Part")]
		public List<Part>? Parts { get; init; }

		[JsonPropertyName("optimizedForStreaming")]
		public int? OptimizedForStreaming { get; init; }

		[JsonPropertyName("audioProfile")]
		public string? AudioProfile { get; init; }

		[JsonPropertyName("has64bitOffsets")]
		public bool? Has64bitOffsets { get; init; }
	}
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

}
