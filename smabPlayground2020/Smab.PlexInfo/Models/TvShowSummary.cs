namespace Smab.PlexInfo.Models;

public record TvShowSummary : ItemSummary {
	public int Seasons { get; init; }
	public int Episodes { get; init; }
	public int ViewedEpisodes { get; init; }
};
