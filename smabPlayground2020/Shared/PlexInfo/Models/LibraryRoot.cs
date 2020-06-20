using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace smabPlayground2020.Shared.PlexInfo.Models
{

	public class LibraryRoot
	{
		[JsonPropertyName("MediaContainer")]
		public MediaContainer MediaContainer { get; set; } = new MediaContainer();
	}

	public class MediaContainer
	{
		[JsonPropertyName("size")]
		public int Size { get; set; }

		[JsonPropertyName("allowSync")]
		public bool AllowSync { get; set; }

		[JsonPropertyName("art")]
		public string Art { get; set; } = "";

		[JsonPropertyName("content")]
		public string Content { get; set; } = "";

		[JsonPropertyName("identifier")]
		public string Identifier { get; set; } = "";

		[JsonPropertyName("mediaTagPrefix")]
		public string MediaTagPrefix { get; set; } = "";

		[JsonPropertyName("mediaTagVersion")]
		public int MediaTagVersion { get; set; }

		[JsonPropertyName("title1")]
		public string Title1 { get; set; } = "";

		[JsonPropertyName("title2")]
		public string Title2 { get; set; } = "";

		[JsonPropertyName("Directory")]
		public List<Directory> Directory { get; set; } = new List<Directory>();
	}

	public class Directory
	{
		[JsonPropertyName("key")]
		public string Key { get; set; } = "";

		[JsonPropertyName("title")]
		public string Title { get; set; } = "";
	}

}
