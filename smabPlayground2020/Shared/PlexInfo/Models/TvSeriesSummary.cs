using System;
using System.Text.Json.Serialization;

using smabPlayground2020.Shared.Helpers;

namespace smab.PlexInfo.Models
{
	public class TvSeriesSummary
	{
		public int LibraryId { get; set; }
		public string LibraryTitle { get; set; } = "";
		public int Id { get; set; }
		public string Title { get; set; } = "";
		public int? Year { get; set; }
		public int Duration { get; set; }
		public string? Thumb { get; set; }
		public int Seasons { get; set; }
		public int Episodes { get; set; }
		public int ViewedEpisodes { get; set; }
		public DateTime? AddedAt { get; set; }
		public double? Rating { get; set; }
		public DateTime? OriginallyAvailableAt { get; set; }
	}
}
