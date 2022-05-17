namespace Smab.PlexInfo.Models;

public record MovieSummary
(
	int LibraryId,
	string LibraryTitle,
	int Id,
	string Title,
	int? Year,
	int Duration,
	string? Thumb,
	DateTime? AddedAt,
	double? Rating
) {
	[JsonConverter(typeof(JsonDateOnlyConverter))]
	public DateOnly? OriginallyAvailableAt { get; init; }
};
