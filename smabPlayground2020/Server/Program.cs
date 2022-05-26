using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.OpenApi.Models;

using Smab.PlexInfo;
using Smab.PlexInfo.Server;
using Smab.ReadingBadminton;

using smabPlayground2020.Server.EndPoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
	.AddJsonOptions(options => {
		options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
	})
	.AddPlexInfo(options => new PlexInfoServerOptions()
	{
		ThumbnailCacheTime = 7200
	});

builder.Services.AddSwaggerGen(c => {
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "smabPlayground2020", Version = "v1" });
});

// Plex settings
builder.Services.Configure<PlexSettings>(builder.Configuration.GetSection(nameof(PlexSettings)));

builder.Services.AddHttpClient<IPlexClient, PlexClient>()
	// The local Plex Server will not have a proper certificate so we have to ignore this
	.ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler() {
		ClientCertificateOptions = ClientCertificateOption.Manual,
		ServerCertificateCustomValidationCallback =
		(httpRequestMessage, cert, certChain, policyErrors) => {
			return true;
		}
	});

builder.Services.AddSingleton<IReadingBadmintonReader, ReadingBadmintonReader>();

builder.Services.AddRazorPages();
builder.Services.AddResponseCaching();
builder.Services.AddResponseCompression(options => {
	options.Providers.Add<BrotliCompressionProvider>();
	options.Providers.Add<GzipCompressionProvider>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
	app.UseDeveloperExceptionPage();
	app.UseWebAssemblyDebugging();
	app.UseSwagger();
	app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "smabPlayground2020 v1"));
} else {
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();

app.UseResponseCompression();
app.UseResponseCaching();
app.UseStaticFiles(new StaticFileOptions {
	// Second reference is required because Blazor does interesting things with the first
	// This is used to control static file cache time
	OnPrepareResponse = ctx => ctx.Context.Response.Headers.Append("Cache-Control", $"public, max-age={3600}")
});

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.MapGet("/calendar/badminton/{Division}/{TeamName}", BadmintonCalendarEndPoint.GetCalendarByTeam);

app.Run();
