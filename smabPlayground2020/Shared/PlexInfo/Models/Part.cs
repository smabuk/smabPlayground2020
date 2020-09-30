using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace smab.PlexInfo.Models
{
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
	public class Part
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("key")]
		public string Key { get; set; }

		[JsonPropertyName("duration")]
		public int Duration { get; set; }

		[JsonPropertyName("file")]
		public string File { get; set; }

		[JsonPropertyName("size")]
		public long Size { get; set; }

		[JsonPropertyName("container")]
		public string Container { get; set; }

		[JsonPropertyName("videoProfile")]
		public string VideoProfile { get; set; }

		[JsonPropertyName("audioProfile")]
		public string AudioProfile { get; set; }

		[JsonPropertyName("has64bitOffsets")]
		public bool Has64bitOffsets { get; set; }

		[JsonPropertyName("optimizedForStreaming")]
		public bool OptimizedForStreaming { get; set; }

		[JsonPropertyName("hasThumbnail")]
		public string HasThumbnail { get; set; }

		[JsonPropertyName("Stream")]
		public List<Stream>? Streams { get; set; }

	}
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

}
