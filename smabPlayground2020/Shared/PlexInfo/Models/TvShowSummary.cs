using System;
using System.Text.Json.Serialization;

using smabPlayground2020.Shared.Helpers;

namespace smab.PlexInfo.Models
{
	public class TvShowSummary
	{
		public int LibraryId { get; init; }
		public string LibraryTitle { get; init; } = "";
		public int Id { get; init; }
		public string Title { get; init; } = "";
		public int? Year { get; init; }
		public int Duration { get; init; }
		public string? Thumb { get; init; }
		public int Seasons { get; init; }
		public int Episodes { get; init; }
		public int ViewedEpisodes { get; init; }
		public DateTime? AddedAt { get; init; }
		public double? Rating { get; init; }
		public DateTime? OriginallyAvailableAt { get; init; }
	}
}
