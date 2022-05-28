using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.OpenApi.Models;

using Smab.PlexInfo;
using Smab.PlexInfo.Server;
using Smab.ReadingBadminton;

using smabPlayground2020.Server.EndPoints;

var builder = WebApplication.CreateBuilder(args);

// Plex settings
builder.Services.AddPlexInfo(options =>
{
	options.Server = builder.Configuration.GetValue<string>($"{nameof(PlexSettings)}:{nameof(PlexSettings.Server)}") ?? "";
	options.Token = builder.Configuration.GetValue<string>($"{nameof(PlexSettings)}:{nameof(PlexSettings.Token)}") ?? "";
	options.ThumbnailCacheDuration = builder.Configuration.GetValue<int?>($"{nameof(PlexSettings)}:{nameof(PlexSettings.ThumbnailCacheDuration)}") ?? 10080;
});

builder.Services.AddControllersWithViews()
	.AddJsonOptions(options => {
		options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
	})
	.ConfigurePlexInfoApis();

builder.Services.AddSwaggerGen(c => {
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "smabPlayground2020", Version = "v1" });
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
