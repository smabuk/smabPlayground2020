using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using smabPlayground2020.Shared.PlexInfo;
using smabPlayground2020.Shared.PlexInfo.Models;

namespace smabPlayground2020.Server
{
	public class PlexClient : IPlexClient
	{
		private readonly HttpClient _httpClient;
		private readonly string token = "";
		private readonly int MOVIE_LIBRARY_ID = 3;
		private readonly int OTHER_MOVIE_LIBRARY_ID = 7;
		private readonly int SHORT_MOVIE_LIBRARY_ID = 8;

		public PlexClient(HttpClient httpClient, IOptions<PlexSettings> plexSettings)
		{
			httpClient.BaseAddress = new Uri(plexSettings.Value.Server);
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			_httpClient = httpClient;
			token = plexSettings.Value.Token;
		}

		public async Task<LibraryItem> GetLibraryRoot()
		{
			LibraryItem? result = await CallPlexApi<LibraryItem>($"library");
			if (result is null)
			{
				throw new NullReferenceException("Library root not found");
			}
			return result;
		}

		public async Task<LibraryItem> GetLibrarySections()
		{
			LibraryItem? result = await CallPlexApi<LibraryItem>($"library/sections");
			if (result is null)
			{
				throw new NullReferenceException("No library sections found");
			}
			return result;
		}

		public async Task<List<LibraryItem>> GetAllMovies()
		{
			List<PlexOption> options = new()
			{
				new("X-Plex-Features", "external-media,indirect-media"),
				new("X-Plex-Model", "bundled"),
				new("type", 1),
				new("includeCollections", false),
				new("includeExternalMedia", true),
				new("includeAdvanced", true),
				new("includeMeta", true),
				new("sort", "titleSort")
			};
			Task<LibraryItem?> task1 = CallPlexApi<LibraryItem>($"library/sections/{MOVIE_LIBRARY_ID}/all", options);
			Task<LibraryItem?> task2 = CallPlexApi<LibraryItem>($"library/sections/{OTHER_MOVIE_LIBRARY_ID}/all", options);
			Task<LibraryItem?> task3 = CallPlexApi<LibraryItem>($"library/sections/{SHORT_MOVIE_LIBRARY_ID}/all", options);
			List<LibraryItem> results = new();
			LibraryItem? result1 = await task1;
			LibraryItem? result2 = await task2;
			LibraryItem? result3 = await task3;
			if (result1 is not null)
			{
				results.Add(result1);
			}
			if (result2 is not null)
			{
				results.Add(result2);
			}
			if (result3 is not null)
			{
				results.Add(result3);
			}
			return results;
		}

		public async Task<List<LibraryItem>> GetAllMovies(int start, int size)
		{
			List<PlexOption> options = new()
			{
				new("X-Plex-Container-Start", start),
				new("X-Plex-Container-Size", size),
				new("X-Plex-Features", "external-media,indirect-media"),
				new("X-Plex-Model", "bundled"),
				new("type", 1),
				new("includeCollections", false),
				new("includeExternalMedia", true),
				new("includeAdvanced", true),
				new("includeMeta", true),
				new("sort", "titleSort")
			};
			LibraryItem? result = await CallPlexApi<LibraryItem>($"library/sections/{MOVIE_LIBRARY_ID}/all", options);
			List<LibraryItem> results = new();
			if (result is null)
			{
				throw new NullReferenceException("No movies found");
			}
			results.Add(result);
			return results;
		}
		public async Task<LibraryItem> GetMovieCollections()
		{
			List<PlexOption> options = new()
			{
				new("X-Plex-Features", "external-media,indirect-media"),
				new("X-Plex-Model", "bundled"),
				new("includeCollections", true),
				new("includeExternalMedia", true),
				new("includeAdvanced", true),
				new("includeMeta", true),
				new("sort", "titleSort")
			};
			LibraryItem? result = await CallPlexApi<LibraryItem>($"library/sections/{MOVIE_LIBRARY_ID}/collections", options);
			if (result is null)
			{
				throw new NullReferenceException("No collections found");
			}
			return result;
		}

		public async Task<LibraryItem?> GetItem(int id)
		{
			LibraryItem? result = await CallPlexApi<LibraryItem>($"library/metadata/{id}");
			return result;
		}

		public async Task<LibraryItem?> GetItemChildren(int id)
		{
			LibraryItem? result = await CallPlexApi<LibraryItem>($"library/metadata/{id}/children");
			return result;
		}

		public async Task<byte[]?> GetPhotoFromUrl(string url, int width = 180, int height = 270)
		{
			List<PlexOption> options = new()
			{
				new("width", width),
				new("height", height),
				new("minsize", true),
				new("upscale", true),
				new("url", url)
			};
			byte[]? result = await CallPlexApiAndReturnImage($"photo/:/transcode", options);
			return result;
		}

		public async Task<LibraryItem> GetRelated(int id)
		{
			List<PlexOption> options = new()
			{
				new("X-Plex-Features", "external-media,indirect-media"),
				new("X-Plex-Model", "bundled"),
				new("exclude-fields", "summary"),
				new("includeExternalMedia", true),
				new("includeExternalMetadata", true),
				new("asyncAugmentMetadata", true)
			};
			LibraryItem? result = await CallPlexApi<LibraryItem>($"hubs/metadata/{id}/related", options);
			if (result is null)
			{
				throw new NullReferenceException("No related movies found");
			}
			return result;
		}


		private async Task<T?> CallPlexApi<T>(string query, IEnumerable<PlexOption>? options = null) where T: class
		{
			string optionsString = "";
			foreach (PlexOption option in options ?? new List<PlexOption>())
			{
				optionsString += $"&{option}";
			}

			var response = await _httpClient.GetAsync($"{query}?X-Plex-Token={token}{optionsString}");

			return response.IsSuccessStatusCode switch
			{
				false => null,
				true when response.Content.Headers.ContentType?.ToString() == "application/json" 
					=> await response.Content.ReadFromJsonAsync<T>(),
				_ => null
			};
		}

		private async Task<byte[]?> CallPlexApiAndReturnImage(string query, IEnumerable<PlexOption>? options = null)
		{
			string optionsString = "";
			foreach (PlexOption option in options ?? new List<PlexOption>())
			{
				optionsString += $"&{option}";
			}

			var response = await _httpClient.GetAsync($"{query}?X-Plex-Token={token}{optionsString}");

			return response.IsSuccessStatusCode switch
			{
				false => null,
				true when response.Content.Headers.ContentType?.ToString() == "image/jpeg"
					=> await response.Content.ReadAsByteArrayAsync(),
				_ => null
			};
		}
	}
}
