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

		public async Task<IList<LibraryItem>> GetAllMovies()
		{
			List<PlexOption> options = new List<PlexOption>
			{
				new PlexOption("X-Plex-Features", "external-media,indirect-media"),
				new PlexOption("X-Plex-Model", "bundled"),
				new PlexOption("type", 1),
				new PlexOption("includeCollections", false),
				new PlexOption("includeExternalMedia", true),
				new PlexOption("includeAdvanced", true),
				new PlexOption("includeMeta", true),
				new PlexOption("sort", "titleSort")
			};
			Task<LibraryItem?> task1 = CallPlexApi<LibraryItem>($"library/sections/{MOVIE_LIBRARY_ID}/all", options);
			Task<LibraryItem?> task2 = CallPlexApi<LibraryItem>($"library/sections/{OTHER_MOVIE_LIBRARY_ID}/all", options);
			Task<LibraryItem?> task3 = CallPlexApi<LibraryItem>($"library/sections/{SHORT_MOVIE_LIBRARY_ID}/all", options);
			IList<LibraryItem> results = new List<LibraryItem>();
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

		public async Task<IList<LibraryItem>> GetAllMovies(int start, int size)
		{
			List<PlexOption> options = new List<PlexOption>
			{
				new PlexOption("X-Plex-Container-Start", start),
				new PlexOption("X-Plex-Container-Size", size),
				new PlexOption("X-Plex-Features", "external-media,indirect-media"),
				new PlexOption("X-Plex-Model", "bundled"),
				new PlexOption("type", 1),
				new PlexOption("includeCollections", false),
				new PlexOption("includeExternalMedia", true),
				new PlexOption("includeAdvanced", true),
				new PlexOption("includeMeta", true),
				new PlexOption("sort", "titleSort")
			};
			LibraryItem? result = await CallPlexApi<LibraryItem>($"library/sections/{MOVIE_LIBRARY_ID}/all", options);
			IList<LibraryItem> results = new List<LibraryItem>();
			if (result is null)
			{
				throw new NullReferenceException("No movies found");
			}
			results.Add(result);
			return results;
		}
		public async Task<LibraryItem> GetMovieCollections()
		{
			List<PlexOption> options = new List<PlexOption>
			{
				new PlexOption("X-Plex-Features", "external-media,indirect-media"),
				new PlexOption("X-Plex-Model", "bundled"),
				new PlexOption("includeCollections", true),
				new PlexOption("includeExternalMedia", true),
				new PlexOption("includeAdvanced", true),
				new PlexOption("includeMeta", true),
				new PlexOption("sort", "titleSort")
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
			List<PlexOption> options = new List<PlexOption>
			{
				new PlexOption("width", width),
				new PlexOption("height", height),
				new PlexOption("minsize", true),
				new PlexOption("upscale", true),
				new PlexOption("url", url)
			};
			byte[]? result = await CallPlexApiAndReturnImage($"photo/:/transcode", options);
			return result;
		}

		public async Task<LibraryItem> GetRelated(int id)
		{
			List<PlexOption> options = new List<PlexOption>
			{
				new PlexOption("X-Plex-Features", "external-media,indirect-media"),
				new PlexOption("X-Plex-Model", "bundled"),
				new PlexOption("exclude-fields", "summary"),
				new PlexOption("includeExternalMedia", true),
				new PlexOption("includeExternalMetadata", true),
				new PlexOption("asyncAugmentMetadata", true)
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
			if (response.IsSuccessStatusCode)
			{

				switch (response.Content.Headers.ContentType?.ToString())
				{
					//case "image/jpeg":
					//	var result = await response.Content.ReadAsStreamAsync();
					//	return result;
					case "application/json":
						try
						{
							return await response.Content.ReadFromJsonAsync<T>();
						}
						catch (NotSupportedException)
						{
							throw;
						}
						catch (JsonException)
						{
							throw;
						}
						catch (Exception)
						{
							throw;
						}
					default:
						break;
				}
			}

			return null;
		}

		private async Task<byte[]?> CallPlexApiAndReturnImage(string query, IEnumerable<PlexOption>? options = null)
		{
			string optionsString = "";
			foreach (PlexOption option in options ?? new List<PlexOption>())
			{
				optionsString += $"&{option}";
			}

			var response = await _httpClient.GetAsync($"{query}?X-Plex-Token={token}{optionsString}");
			if (response.IsSuccessStatusCode)
			{

				switch (response.Content.Headers.ContentType?.ToString())
				{
					case "image/jpeg":
						byte[]? result = await response.Content.ReadAsByteArrayAsync();
						return result;
					case "application/json":
						break;
					default:
						break;
				}
			}

			return null;
		}
	}
}
