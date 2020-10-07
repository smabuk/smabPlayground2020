using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

using smabPlayground2020.Shared.Helpers;

namespace smab.PlexInfo.Models
{
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
	public class LibraryDirectory
	{
		[JsonPropertyName("allowSync")]
		public bool? AllowSync { get; init; }

		[JsonPropertyName("art")]
		public string? Art { get; init; }

		[JsonPropertyName("composite")]
		public string? Composite { get; init; }

		[JsonPropertyName("filters")]
		public bool? Filters { get; init; }

		[JsonPropertyName("refreshing")]
		public bool? Refreshing { get; init; }

		[JsonPropertyName("thumb")]
		public string? Thumb { get; init; }

		[JsonPropertyName("key")]
		public string Key { get; init; }

		[JsonPropertyName("type")]
		public string? Type { get; init; }

		[JsonPropertyName("title")]
		public string Title { get; init; }

		[JsonPropertyName("agent")]
		public string? Agent { get; init; }

		[JsonPropertyName("scanner")]
		public string? Scanner { get; init; }

		[JsonPropertyName("language")]
		public string? Language { get; init; }

		[JsonPropertyName("uuid")]
		public string? Uuid { get; init; }

		[JsonPropertyName("updatedAt")]
		[JsonConverter(typeof(JsonUnixDateConverterWithNulls))]
		public DateTime? UpdatedAt { get; init; }

		[JsonPropertyName("createdAt")]
		[JsonConverter(typeof(JsonUnixDateConverterWithNulls))]
		public DateTime? CreatedAt { get; init; }

		[JsonPropertyName("scannedAt")]
		[JsonConverter(typeof(JsonUnixDateConverterWithNulls))]
		public DateTime? ScannedAt { get; init; }

		[JsonPropertyName("content")]
		public bool? Content { get; init; }

		[JsonPropertyName("directory")]
		public bool? Directory { get; init; }

		[JsonPropertyName("contentChangedAt")]
		[JsonConverter(typeof(JsonUnixDateConverterWithNulls))]
		public DateTime? ContentChangedAt { get; init; }

		[JsonPropertyName("hidden")]
		public int? Hidden { get; init; }

		[JsonPropertyName("Location")]
		public List<Location>? Locations { get; init; }

		[JsonPropertyName("enableAutoPhotoTags")]
		public bool? EnableAutoPhotoTags { get; init; }
	}
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

}
