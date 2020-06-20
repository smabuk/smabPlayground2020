﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using smabPlayground2020.Shared.Helpers;

namespace smabPlayground2020.Shared.PlexInfo.Models
{
	public class LibrarySections
	{
		[JsonPropertyName("MediaContainer")]
		public LibrarySectionsMediaContainer MediaContainer { get; set; } = new LibrarySectionsMediaContainer();
	}

	public class LibrarySectionsMediaContainer
	{
		[JsonPropertyName("size")]
		public int Size { get; set; }

		[JsonPropertyName("allowAsync")]
		public bool AllowSync { get; set; }

		[JsonPropertyName("identifier")]
		public string Identifier { get; set; } = "";

		[JsonPropertyName("mediaTagPrefix")]
		public string MediaTagPrefix { get; set; } = "";

		[JsonPropertyName("mediaTagVersion")]
		public int MediaTagVersion { get; set; }

		[JsonPropertyName("title1")]
		public string Title1 { get; set; } = "";

		[JsonPropertyName("Directory")]
		public List<LibrarySectionsDirectory> Directory { get; set; } = new List<LibrarySectionsDirectory>();
	}

	public class LibrarySectionsDirectory
	{
		[JsonPropertyName("allowSync")]
		public bool AllowSync { get; set; }

		[JsonPropertyName("art")]
		public string Art { get; set; } = "";

		[JsonPropertyName("composite")]
		public string Composite { get; set; } = "";

		[JsonPropertyName("filters")]
		public bool Filters { get; set; }

		[JsonPropertyName("refreshing")]
		public bool Refreshing { get; set; }

		[JsonPropertyName("thumb")]
		public string Thumb { get; set; } = "";

		[JsonPropertyName("key")]
		public string Key { get; set; } = "";

		[JsonPropertyName("type")]
		public string Type { get; set; } = "";

		[JsonPropertyName("title")]
		public string Title { get; set; } = "";

		[JsonPropertyName("agent")]
		public string Agent { get; set; } = "";

		[JsonPropertyName("scanner")]
		public string Scanner { get; set; } = "";

		[JsonPropertyName("language")]
		public string Language { get; set; } = "";

		[JsonPropertyName("uuid")]
		public string Uuid { get; set; } = "";

		[JsonPropertyName("updatedAt")]
		[JsonConverter(typeof(JsonUnixDateConverter))]
		public DateTime UpdatedAt { get; set; }

		[JsonPropertyName("createdAt")]
		[JsonConverter(typeof(JsonUnixDateConverter))]
		public DateTime CreatedAt { get; set; }

		[JsonPropertyName("scannedAt")]
		[JsonConverter(typeof(JsonUnixDateConverter))]
		public DateTime ScannedAt { get; set; }

		[JsonPropertyName("content")]
		public bool Content { get; set; }

		[JsonPropertyName("directory")]
		public bool Directory { get; set; }

		[JsonPropertyName("contentChangedAt")]
		[JsonConverter(typeof(JsonUnixDateConverter))]
		public DateTime ContentChangedAt { get; set; }

		[JsonPropertyName("hidden")]
		public int Hidden { get; set; }

		[JsonPropertyName("Location")]
		public List<Location> Location { get; set; } = new List<Location>();

		[JsonPropertyName("enableAutoPhotoTags")]
		public bool EnableAutoPhotoTags { get; set; }
	}

	public class Location
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("path")]
		public string Path { get; set; } = "";
	}

}
