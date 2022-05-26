namespace Smab.PlexInfo;

public record PlexSettings {
	public string Server { get; init; } = "";
	public string Token { get; init; } = "";
	public int ThumbnailCacheDuration { get; init; } = 3600;
}
