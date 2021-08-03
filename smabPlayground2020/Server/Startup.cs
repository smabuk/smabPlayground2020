using System.Linq;
using System.Net.Http;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

using smab.PlexInfo;

using smabPlayground2020.Server.Data;
using smabPlayground2020.Server.Models;

namespace smabPlayground2020.Server {
	public class Startup {
		public Startup(IConfiguration configuration, IWebHostEnvironment env) {
			Configuration = configuration;
			Environment = env;
		}

		public IConfiguration Configuration { get; }
		public IWebHostEnvironment Environment { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services) {
			// Core services
			services.AddRazorPages();
			services.AddResponseCaching();
			services.AddResponseCompression(options => {
				options.Providers.Add<BrotliCompressionProvider>();
				options.Providers.Add<GzipCompressionProvider>();
			});


			// Identity and Authorization and Authentication
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

			services.AddDatabaseDeveloperPageExceptionFilter();

			services.AddDefaultIdentity<ApplicationUser>(options => {
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

			services.AddIdentityServer()
				.AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

			services.AddAuthentication()
				.AddIdentityServerJwt();


			// Web APIs
			services.AddControllersWithViews()
				.AddJsonOptions(options => {
					options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
				});
			services.AddSwaggerGen(c => {
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "smabPlayground2020", Version = "v1" });
			});



			// Plex settings
			services.Configure<PlexSettings>(Configuration.GetSection(nameof(PlexSettings)));

			services.AddHttpClient<IPlexClient, PlexClient>()
				// The local Plex Server will not have a proper certificate so we have to ignore this
				.ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler() {
					ClientCertificateOptions = ClientCertificateOption.Manual,
					ServerCertificateCustomValidationCallback =
					(httpRequestMessage, cert, certChain, policyErrors) => {
						return true;
					}
				});

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger) {
			if (env.IsDevelopment()) {
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

			// Security settings
			app.UseHttpsRedirection();
			app.UseBlazorFrameworkFiles();
			app.UseStaticFiles();


			// Basic site settings
			app.UseResponseCompression();
			app.UseResponseCaching();
			app.UseStaticFiles(new StaticFileOptions {
				// Second reference is required because Blazor does interesting things with the first
				// This is used to control static file cache time
				OnPrepareResponse = ctx => ctx.Context.Response.Headers.Append("Cache-Control", $"public, max-age={3600}")
			});

			// Identiyy, Auth and Routing
			app.UseIdentityServer();
			app.UseAuthentication();
			app.UseRouting();
			app.UseAuthorization();


			app.UseEndpoints(endpoints => {
				endpoints.MapRazorPages();
				endpoints.MapControllers();
				endpoints.MapFallbackToFile("index.html");
				logger.LogInformation("Application Started");
			});
		}
	}
}
