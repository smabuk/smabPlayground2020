using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Syncfusion.Blazor;
using smab.PlexInfo;

namespace smabPlayground2020.Client
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			//Register Syncfusion license 
			Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(@"MzU0MDYwQDMxMzgyZTMzMmUzMFJzUGpsYk1MMDdYSGR1d2EyUjlGbFhJYWt0RlIwZmV5UG1pMHR0S2JsVmc9;MzU0MDYxQDMxMzgyZTMzMmUzMERISmYrYmV1Z0k2ajZpNHJkN1JwbFI1ajFuU0ZoVHN1b0JydGFKM3Z3TU09");

			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.Services.AddSyncfusionBlazor();
			builder.RootComponents.Add<App>("#app");

			builder.Services.AddHttpClient("smabPlayground2020.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
				.AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

			builder.Services.AddHttpClient<PlexInfoClient>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

			// Supply HttpClient instances that include access tokens when making requests to the server project
			builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("smabPlayground2020.ServerAPI"));

			builder.Services.AddSingleton<PlexInfoState>();

			builder.Services.AddApiAuthorization();

			await builder.Build().RunAsync();
		}
	}
}
