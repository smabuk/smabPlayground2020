namespace Smab.PlexInfo.Models;
public record ItemSummary {
	public int LibraryId { get; init; }
	public string LibraryTitle { get; init; } = default!;
	public int Id { get; init; }
	public string Title { get; init; } = default!;
	public int? Year { get; init; }
	public int Duration { get; init; }
	public string? Thumb { get; init; }
	public DateTime? AddedAt { get; init; }
	public double? Rating { get; init; }
	[JsonConverter(typeof(JsonDateOnlyConverter))]
	public DateOnly? OriginallyAvailableAt { get; init; }
}
