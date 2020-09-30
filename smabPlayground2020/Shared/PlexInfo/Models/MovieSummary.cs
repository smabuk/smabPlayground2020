using System;
using System.Text.Json.Serialization;

using smabPlayground2020.Shared.Helpers;

namespace smab.PlexInfo.Models
{
	public class MovieSummary
	{
		public int LibraryId { get; set; }
		public string LibraryTitle { get; set; } = "";
		public int Id { get; set; }
		public string Title { get; set; } = "";
		public int? Year { get; set; }
		public int Duration { get; set; }
		public string? Thumb { get; set; }
		public DateTime? AddedAt { get; set; }
		public double? Rating { get; set; }
		public string? OriginallyAvailableAt { get; set; }
	}
}
