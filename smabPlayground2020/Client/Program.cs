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

namespace smabPlayground2020.Client
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			//Register Syncfusion license 
			if (System.IO.File.Exists(System.IO.Directory.GetCurrentDirectory() + "/SyncfusionLicense.txt"))
			{
				string licenseKey = System.IO.File.ReadAllText(System.IO.Directory.GetCurrentDirectory() + "/SyncfusionLicense.txt");
				Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(licenseKey);
			}

			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.Services.AddSyncfusionBlazor();
			builder.RootComponents.Add<App>("app");

			builder.Services.AddHttpClient("smabPlayground2020.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
				.AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

			// Supply HttpClient instances that include access tokens when making requests to the server project
			builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("smabPlayground2020.ServerAPI"));

			builder.Services.AddApiAuthorization();

			await builder.Build().RunAsync();
		}
	}
}
