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
			Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(@"MjcyNjI5QDMxMzgyZTMxMmUzMFJpWitrVGhzL2hzZ294M3Qwem9SNFdBbENCSVRSMEh2eTlCSWZFYzdSWUk9;MjcyNjMwQDMxMzgyZTMxMmUzMFFGSk0wVU1kQU5PWDdBczVpc1c4M2ZDY09Sb0w2OGROZ01rVnRmV01KUFE9");

			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.Services.AddSyncfusionBlazor();
			builder.RootComponents.Add<App>("app");

			builder.Services.AddHttpClient("smabPlayground2020.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
				.AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

			builder.Services.AddHttpClient<PlexInfoClient>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

			// Supply HttpClient instances that include access tokens when making requests to the server project
			builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("smabPlayground2020.ServerAPI"));

			builder.Services.AddApiAuthorization();

			await builder.Build().RunAsync();
		}
	}
}
