using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

using smabPlayground2020.Shared.Helpers;

namespace smabPlayground2020.Shared.PlexInfo.Models
{
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
	public class LibraryDirectory
	{
		[JsonPropertyName("allowSync")]
		public bool? AllowSync { get; set; }

		[JsonPropertyName("art")]
		public string? Art { get; set; }

		[JsonPropertyName("composite")]
		public string? Composite { get; set; }

		[JsonPropertyName("filters")]
		public bool? Filters { get; set; }

		[JsonPropertyName("refreshing")]
		public bool? Refreshing { get; set; }

		[JsonPropertyName("thumb")]
		public string? Thumb { get; set; }

		[JsonPropertyName("key")]
		public string Key { get; set; }

		[JsonPropertyName("type")]
		public string? Type { get; set; }

		[JsonPropertyName("title")]
		public string Title { get; set; }

		[JsonPropertyName("agent")]
		public string? Agent { get; set; }

		[JsonPropertyName("scanner")]
		public string? Scanner { get; set; }

		[JsonPropertyName("language")]
		public string? Language { get; set; }

		[JsonPropertyName("uuid")]
		public string? Uuid { get; set; }

		[JsonPropertyName("updatedAt")]
		[JsonConverter(typeof(JsonUnixDateConverterWithNulls))]
		public DateTime? UpdatedAt { get; set; }

		[JsonPropertyName("createdAt")]
		[JsonConverter(typeof(JsonUnixDateConverterWithNulls))]
		public DateTime? CreatedAt { get; set; }

		[JsonPropertyName("scannedAt")]
		[JsonConverter(typeof(JsonUnixDateConverterWithNulls))]
		public DateTime? ScannedAt { get; set; }

		[JsonPropertyName("content")]
		public bool? Content { get; set; }

		[JsonPropertyName("directory")]
		public bool? Directory { get; set; }

		[JsonPropertyName("contentChangedAt")]
		[JsonConverter(typeof(JsonUnixDateConverterWithNulls))]
		public DateTime? ContentChangedAt { get; set; }

		[JsonPropertyName("hidden")]
		public int? Hidden { get; set; }

		[JsonPropertyName("Location")]
		public IList<Location>? Locations { get; set; }

		[JsonPropertyName("enableAutoPhotoTags")]
		public bool? EnableAutoPhotoTags { get; set; }
	}
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

}
