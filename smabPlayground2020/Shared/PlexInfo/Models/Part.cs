using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace smab.PlexInfo.Models
{
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
	public class Part
	{
		[JsonPropertyName("id")]
		public int Id { get; init; }

		[JsonPropertyName("key")]
		public string Key { get; init; }

		[JsonPropertyName("duration")]
		public int Duration { get; init; }

		[JsonPropertyName("file")]
		public string File { get; init; }

		[JsonPropertyName("size")]
		public long Size { get; init; }

		[JsonPropertyName("container")]
		public string Container { get; init; }

		[JsonPropertyName("videoProfile")]
		public string VideoProfile { get; init; }

		[JsonPropertyName("audioProfile")]
		public string AudioProfile { get; init; }

		[JsonPropertyName("has64bitOffsets")]
		public bool Has64bitOffsets { get; init; }

		[JsonPropertyName("optimizedForStreaming")]
		public bool OptimizedForStreaming { get; init; }

		[JsonPropertyName("hasThumbnail")]
		public string HasThumbnail { get; init; }

		[JsonPropertyName("Stream")]
		public List<Stream>? Streams { get; init; }

	}
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

}
