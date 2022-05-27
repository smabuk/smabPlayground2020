namespace Smab.PlexInfo;

public record PlexSettings {
	public string Server { get; set; } = "";
	public string Token { get; set; } = "";
	public string RootPath { get; set; } = "/";
	public int ThumbnailCacheDuration { get; set; } = 3600;
}
