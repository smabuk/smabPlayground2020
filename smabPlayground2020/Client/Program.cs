using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using smabPlayground2020.Client;

using Syncfusion.Blazor;

WebAssemblyHostBuilder? builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("smabPlayground2020.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
		.AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("smabPlayground2020.ServerAPI"));

builder.Services.AddApiAuthorization();

builder.Services.AddScoped<SmabJsInterop>();

//Register Syncfusion license 
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(@"MzU0MDYwQDMxMzgyZTMzMmUzMFJzUGpsYk1MMDdYSGR1d2EyUjlGbFhJYWt0RlIwZmV5UG1pMHR0S2JsVmc9;MzU0MDYxQDMxMzgyZTMzMmUzMERISmYrYmV1Z0k2ajZpNHJkN1JwbFI1ajFuU0ZoVHN1b0JydGFKM3Z3TU09");
builder.Services.AddSyncfusionBlazor();

// PlexInfo
builder.Services.AddHttpClient<PlexInfoClient>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
builder.Services.AddSingleton<PlexInfoState>();

await builder.Build().RunAsync();
