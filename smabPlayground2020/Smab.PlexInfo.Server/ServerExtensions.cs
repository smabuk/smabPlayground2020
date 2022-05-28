using Microsoft.Extensions.DependencyInjection;

namespace Smab.PlexInfo.Server;
public static class ServerExtensions
{
	private static PlexSettings _plexSettings = new();

	public static IServiceCollection AddPlexInfo(this IServiceCollection services, Action<PlexSettings>? options = null)
	{
		options?.Invoke(_plexSettings);
		services.Configure(options);

		services.AddHttpClient<IPlexClient, PlexClient>()
		// The local Plex Server will not have a proper certificate so we have to ignore this
		.ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler()
		{
			ClientCertificateOptions = ClientCertificateOption.Manual,
			ServerCertificateCustomValidationCallback =
			(httpRequestMessage, cert, certChain, policyErrors) =>
			{
				return true;
			}
		});

		return services;
	}

	public static IMvcBuilder ConfigurePlexInfoApis(this IMvcBuilder builder, Action<PlexSettings>? options = null)
	{
		ArgumentNullException.ThrowIfNull(nameof(builder));

		PlexSettings plexSettings = new();
		options?.Invoke(plexSettings);
		if (options == null)
		{
			plexSettings.ThumbnailCacheDuration = _plexSettings.ThumbnailCacheDuration;
		}
		else
		{
			_plexSettings.ThumbnailCacheDuration = plexSettings.ThumbnailCacheDuration;
		}

		builder.AddMvcOptions(opt =>
			opt.CacheProfiles.Add("PlexInfoThumbnails",
			new()
			{
				// Multiply by 60 to convert from duration in minutes to seconds
				Duration = plexSettings.ThumbnailCacheDuration * 60
			})
		);

		return builder;
	}

	//public static IApplicationBuilder MapPlexInfo(this IApplicationBuilder app, Action<PlexInfoServerOptions>? options = null)
	//{
	//	ArgumentNullException.ThrowIfNull(app, nameof(app));
	//	return app;
	//}
}
