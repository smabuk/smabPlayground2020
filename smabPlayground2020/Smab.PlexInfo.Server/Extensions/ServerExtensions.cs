using Microsoft.Extensions.DependencyInjection;

namespace Smab.PlexInfo.Server;
public static class ServerExtensions
{
	public static IServiceCollection AddPlexInfoController(this IServiceCollection services, Action<PlexInfoServerOptions>? options = null)
	{
		services.Configure(options);
		return services;
	}
}
