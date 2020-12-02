using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

using smabPlayground2020.Shared.Helpers;

namespace smab.PlexInfo.Models {
	public record LibraryDirectory
	(
		bool? AllowSync,
		string? Art,
		string? Composite,
		bool? Filters,
		bool? Refreshing,
		string? Thumb,
		string Key,
		string? Type,
		string Title,
		string? Agent,
		string? Scanner,
		string? Language,
		string? Uuid,
		bool? Content,
		bool? Directory,
		int? Hidden,
		List<Location>? Location,
		bool? EnableAutoPhotoTags
	) {
		[JsonConverter(typeof(JsonUnixDateConverterWithNulls))]
		public DateTime? UpdatedAt { get; init; }

		[JsonConverter(typeof(JsonUnixDateConverterWithNulls))]
		public DateTime? CreatedAt { get; init; }

		[JsonConverter(typeof(JsonUnixDateConverterWithNulls))]
		public DateTime? ScannedAt { get; init; }

		[JsonConverter(typeof(JsonUnixDateConverterWithNulls))]
		public DateTime? ContentChangedAt { get; init; }
	};
}
