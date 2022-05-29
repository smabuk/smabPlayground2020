﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Smab.PlexInfo.Server;
public static class PlexInfoServerExtensions
{
	private static PlexSettings _plexSettings = new();

	public static WebApplicationBuilder? AddPlexInfoServer(this WebApplicationBuilder? builder)
	{
		ArgumentNullException.ThrowIfNull(builder, nameof(builder));

		_plexSettings = builder.Configuration.GetSection(nameof(PlexSettings)).Get<PlexSettings>();

		builder.Services.Configure<PlexSettings>(builder.Configuration.GetSection(nameof(PlexSettings)));

		// Register the HttpClient for use in the controllers and services
		builder.Services.AddHttpClient<IPlexClient, PlexClient>()
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

		return builder;
	}

	public static WebApplicationBuilder? AddPlexInfoServer(this WebApplicationBuilder? builder, Action<PlexSettings> options)
	{
		ArgumentNullException.ThrowIfNull(builder, nameof(builder));

		builder.AddPlexInfoServer();
		
		builder.Services.PostConfigure(options);
			
		PlexSettings plexSettings = new();
		options.Invoke(plexSettings);

		_plexSettings.Server = plexSettings.Server ?? _plexSettings.Server;
		_plexSettings.Token = plexSettings.Token ?? _plexSettings.Token;
		_plexSettings.ThumbnailCacheDuration = plexSettings.ThumbnailCacheDuration ?? _plexSettings.ThumbnailCacheDuration;

		return builder;
	}

	public static IMvcBuilder ConfigurePlexInfoApis(this IMvcBuilder builder, Action<PlexSettings>? options = null)
	{
		ArgumentNullException.ThrowIfNull(nameof(builder));

		PlexSettings plexSettings = new();
		options?.Invoke(plexSettings);

		_plexSettings.ThumbnailCacheDuration = plexSettings.ThumbnailCacheDuration ?? _plexSettings.ThumbnailCacheDuration;

		builder.AddMvcOptions(opt =>
			opt.CacheProfiles.Add("PlexInfoThumbnails",
			new()
			{
				// Multiply by 60 to convert from duration in minutes to seconds
				Duration = _plexSettings.ThumbnailCacheDuration * 60
			})
		);

		return builder;
	}
}
