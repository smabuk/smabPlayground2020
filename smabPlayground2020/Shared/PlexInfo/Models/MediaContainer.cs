using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace smabPlayground2020.Shared.PlexInfo.Models
{
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
	public class MediaContainer
	{
		[JsonPropertyName("size")]
		public int Size { get; set; }

		[JsonPropertyName("claimed")]
		public bool? Claimed { get; set; }

		[JsonPropertyName("machineIdentifier")]
		public string? MachineIdentifier { get; set; }

		[JsonPropertyName("version")]
		public string? Version { get; set; }

		[JsonPropertyName("allowSync")]
		public bool AllowSync { get; set; }

		[JsonPropertyName("augmentationKey")]
		public string? AugmentationKey { get; set; }

		[JsonPropertyName("art")]
		public string? Art { get; set; }

		[JsonPropertyName("content")]
		public string? Content { get; set; }

		[JsonPropertyName("identifier")]
		public string Identifier { get; set; }

		[JsonPropertyName("librarySectionID")]
		public int? LibrarySectionId { get; set; }

		[JsonPropertyName("librarySectionTitle")]
		public string? LibrarySectionTitle { get; set; }

		[JsonPropertyName("librarySectionUUID")]
		public string? LibrarySectionUuid { get; set; }

		[JsonPropertyName("mediaTagPrefix")]
		public string? MediaTagPrefix { get; set; }

		[JsonPropertyName("mediaTagVersion")]
		public int? MediaTagVersion { get; set; }

		[JsonPropertyName("thumb")]
		public string? Thumb { get; set; }

		[JsonPropertyName("title1")]
		public string? Title1 { get; set; }

		[JsonPropertyName("title2")]
		public string? Title2 { get; set; }

		[JsonPropertyName("viewGroup")]
		public string? ViewGroup { get; set; }

		[JsonPropertyName("viewMode")]
		public int? ViewMode { get; set; }




		[JsonPropertyName("Directory")]
		public List<LibraryDirectory>? Directories { get; set; }

		[JsonPropertyName("Metadata")]
		public List<Metadata>? Metadata { get; set; }

		[JsonPropertyName("Hub")]
		public List<Hub>? Hubs { get; set; }

		[JsonPropertyName("Setting")]
		public List<Setting>? Settings { get; set; }

		[JsonPropertyName("Server")]
		public List<Server>? Servers { get; set; }
	}
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

}
