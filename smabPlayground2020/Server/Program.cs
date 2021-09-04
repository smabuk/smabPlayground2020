using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

using smab.PlexInfo;
using smab.TT;

using smabPlayground2020.Server;
using smabPlayground2020.Server.Data;
using smabPlayground2020.Server.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => {
		options.SignIn.RequireConfirmedAccount = false;
		options.Password.RequiredLength = 6;
		options.Password.RequireDigit = false;
		options.Password.RequireUppercase = false;
		options.Password.RequireLowercase = false;
		options.Password.RequireNonAlphanumeric = false;
		options.User.RequireUniqueEmail = true;
	})
	.AddRoles<IdentityRole>()
	.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddIdentityServer()
	.AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

builder.Services.AddAuthentication()
	.AddIdentityServerJwt();

builder.Services.AddControllersWithViews()
	.AddJsonOptions(options => {
		options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
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

builder.Services.AddScoped<ITT365Service, TT365Reader>();


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
	app.UseMigrationsEndPoint();
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
app.UseStaticFiles();

app.UseResponseCompression();
app.UseResponseCaching();
app.UseStaticFiles(new StaticFileOptions {
	// Second reference is required because Blazor does interesting things with the first
	// This is used to control static file cache time
	OnPrepareResponse = ctx => ctx.Context.Response.Headers.Append("Cache-Control", $"public, max-age={3600}")
});

app.UseRouting();

app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
