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

		public PlexClient(HttpClient httpClient, IOptions<PlexSettings> plexSettings)
		{
			httpClient.BaseAddress = new Uri(plexSettings.Value.Server);
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			_httpClient = httpClient;
			token = plexSettings.Value.Token;
		}

		public async Task<LibraryRoot> GetLibraryRoot()
		{
			LibraryRoot? result = await CallPlexApi<LibraryRoot>($"library");
			if (result is null)
			{
				throw new NullReferenceException("Library root not found");
			}
			return result;
		}

		public async Task<LibrarySections> GetLibrarySections()
		{
			LibrarySections? result = await CallPlexApi<LibrarySections>($"library/sections");
			if (result is null)
			{
				throw new NullReferenceException("No library sections found");
			}
			return result;
		}

		public async Task<LibraryMovies> GetAllMovies()
		{
			List<PlexOption> options = new List<PlexOption>
			{
				new PlexOption("includeCollections", false),
				new PlexOption("sort", "titleSort")
			};
			LibraryMovies? result = await CallPlexApi<LibraryMovies>($"library/sections/3/all", options);
			if (result is null)
			{
				throw new NullReferenceException("No movies found");
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
				try
				{
					T result = await response.Content.ReadFromJsonAsync<T>();
					return result;
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
			}

			return null;
		}
	}
}
