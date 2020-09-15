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
using smabPlayground2020.Shared.PlexInfo;

namespace smabPlayground2020.Client
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			//Register Syncfusion license 
			Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(@"Mjk3NzYyQDMxMzgyZTMyMmUzMEJjcTdIZVR2cjArQm5GVjgxeGZrbW85Q0dwdmgvN2hjcjlFczdjZGFNVDA9;Mjk3NzYzQDMxMzgyZTMyMmUzMEZLcmg1aGRsei9LUmtoMW5YUDBJMjM5bktYdHlhRXNwU0Z3MDZnblFBZTg9");

			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.Services.AddSyncfusionBlazor();
			builder.RootComponents.Add<App>("app");

			builder.Services.AddHttpClient("smabPlayground2020.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
				.AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

			builder.Services.AddHttpClient<PlexInfoClient>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

			// Supply HttpClient instances that include access tokens when making requests to the server project
			builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("smabPlayground2020.ServerAPI"));

			builder.Services.AddSingleton<PlexInfoState>();

			builder.Services.AddApiAuthorization();

			await builder.Build().RunAsync();
		}
	}
}
