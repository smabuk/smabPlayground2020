using System.Text.Json.Serialization;

namespace smabPlayground2020.Shared.PlexInfo.Models
{
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
	}

}
