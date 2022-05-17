namespace Smab.PlexInfo.Models;

public record TvShowSummary
(
	int LibraryId,
	string LibraryTitle,
	int Id,
	string Title,
	int? Year,
	int Duration,
	string? Thumb,
	int Seasons,
	int Episodes,
	int ViewedEpisodes,
	DateTime? AddedAt,
	double? Rating
) {
	[JsonConverter(typeof(JsonDateOnlyConverter))]
	public DateOnly? OriginallyAvailableAt { get; init; }
};
