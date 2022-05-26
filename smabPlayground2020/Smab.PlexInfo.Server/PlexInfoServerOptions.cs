namespace Smab.PlexInfo.Server;

public record class PlexInfoServerOptions
(
	string? RootPath = "",
	int ThumbnailCacheTime = 3600
);