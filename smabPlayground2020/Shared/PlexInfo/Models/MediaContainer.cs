using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace smab.PlexInfo.Models
{
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
	public class MediaContainer
	{
		[JsonPropertyName("size")]
		public int Size { get; init; }

		[JsonPropertyName("claimed")]
		public bool? Claimed { get; init; }

		[JsonPropertyName("machineIdentifier")]
		public string? MachineIdentifier { get; init; }

		[JsonPropertyName("version")]
		public string? Version { get; init; }

		[JsonPropertyName("allowSync")]
		public bool AllowSync { get; init; }

		[JsonPropertyName("augmentationKey")]
		public string? AugmentationKey { get; init; }

		[JsonPropertyName("art")]
		public string? Art { get; init; }

		[JsonPropertyName("content")]
		public string? Content { get; init; }

		[JsonPropertyName("identifier")]
		public string Identifier { get; init; }

		[JsonPropertyName("librarySectionID")]
		public int? LibrarySectionId { get; init; }

		[JsonPropertyName("librarySectionTitle")]
		public string? LibrarySectionTitle { get; init; }

		[JsonPropertyName("librarySectionUUID")]
		public string? LibrarySectionUuid { get; init; }

		[JsonPropertyName("mediaTagPrefix")]
		public string? MediaTagPrefix { get; init; }

		[JsonPropertyName("mediaTagVersion")]
		public int? MediaTagVersion { get; init; }

		[JsonPropertyName("thumb")]
		public string? Thumb { get; init; }

		[JsonPropertyName("title1")]
		public string? Title1 { get; init; }

		[JsonPropertyName("title2")]
		public string? Title2 { get; init; }

		[JsonPropertyName("viewGroup")]
		public string? ViewGroup { get; init; }

		[JsonPropertyName("viewMode")]
		public int? ViewMode { get; init; }




		[JsonPropertyName("Directory")]
		public List<LibraryDirectory>? Directories { get; init; }

		[JsonPropertyName("Metadata")]
		public List<Metadata>? Metadata { get; init; }

		[JsonPropertyName("Hub")]
		public List<Hub>? Hubs { get; init; }

		[JsonPropertyName("Setting")]
		public List<Setting>? Settings { get; init; }

		[JsonPropertyName("Server")]
		public List<Server>? Servers { get; init; }
	}
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

}
