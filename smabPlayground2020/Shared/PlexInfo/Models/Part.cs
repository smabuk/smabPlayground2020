using System.Collections.Generic;

namespace smab.PlexInfo.Models {
	public record Part
	(
		int Id,
		string Key,
		int Duration,
		string File,
		long Size,
		string Container,
		string VideoProfile,
		string AudioProfile,
		bool Has64bitOffsets,
		bool OptimizedForStreaming,
		string HasThumbnail,
		List<Stream>? Streams
	);
}
