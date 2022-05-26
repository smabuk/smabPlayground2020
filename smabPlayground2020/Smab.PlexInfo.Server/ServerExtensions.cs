using Microsoft.Extensions.DependencyInjection;

namespace Smab.PlexInfo.Server;
public static class ServerExtensions
{
	public static IMvcBuilder AddPlexInfo(this IMvcBuilder builder, Action<PlexInfoServerOptions>? options = null)
	{
		ArgumentNullException.ThrowIfNull(nameof(builder));

		PlexInfoServerOptions plexInfoServerOptions = new();
		options?.Invoke(plexInfoServerOptions);

		builder.AddMvcOptions(opt =>
			opt.CacheProfiles.Add("PlexInfoThumbnails",
			new()
			{
				Duration = plexInfoServerOptions.ThumbnailCacheTime
			})
		);

		return builder;
	}
	//public static IServiceCollection AddPlexInfo(this IServiceCollection services, Action<PlexInfoServerOptions>? options = null)
	//{
	//	services.Configure(options);
	//	return services;
	//}

	//public static IApplicationBuilder MapPlexInfo(this IApplicationBuilder app, Action<PlexInfoServerOptions>? options = null)
	//{
	//	ArgumentNullException.ThrowIfNull(app, nameof(app));
	//	return app;
	//}
}
