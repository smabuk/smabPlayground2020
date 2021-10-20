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
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(@"NTIyMTAyQDMxMzkyZTMzMmUzME1xMUhmSEhHeXJUbWNhZDdaZUJTTHNqb1VPUks2eC93Ny9HSXN5UngrUGc9;NTIyMTAzQDMxMzkyZTMzMmUzMFF4U2d3TUFNWTNlT1RSMGEzSTZSMzJBOWUxZ1FKb0Q1RWlxYkwwUDBLK009");
builder.Services.AddSyncfusionBlazor();

// PlexInfo
builder.Services.AddHttpClient<PlexInfoClient>(client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
builder.Services.AddSingleton<PlexInfoState>();


await builder.Build().RunAsync();
