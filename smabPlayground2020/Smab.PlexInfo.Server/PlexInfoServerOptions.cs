namespace Smab.PlexInfo.Server;

/// <summary>
/// Options to configure <see cref="PlexInfoController"/> and <see cref="AddPlexInfo"/>.
/// </summary>
public class PlexInfoServerOptions
{
	public string? RootPath { get; set; } = "/";
	public int ThumbnailCacheDuration { get; set; } = 3600;
};