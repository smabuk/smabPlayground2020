using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using smabPlayground2020.Shared.PlexInfo.Models;

namespace smabPlayground2020.Client
{
	public class PlexInfoClient
	{
		public HttpClient Client { get; }

		public PlexInfoClient(HttpClient httpClient)
		{
			Client = httpClient;
		}

		public async Task<LibraryItem?> GetItem(int id)
		{
			LibraryItem? item = await Client.GetFromJsonAsync<LibraryItem>($"PlexInfo/item/{id}");
			return item;
		}

		public async Task<LibraryItem?> GetItemChildren(int id)
		{
			LibraryItem? item = await Client.GetFromJsonAsync<LibraryItem>($"PlexInfo/itemchildren/{id}");
			return item;
		}

		public async Task<LibraryItem> GetLibraries()
		{
			return (await Client.GetFromJsonAsync<LibraryItem>($"PlexInfo/librarysections")) ?? new();
		}

		public async Task<List<MovieSummary>?> GetMoviesList()
		{
			List<MovieSummary>? items = await Client.GetFromJsonAsync<List<MovieSummary>>($"PlexInfo/movieslist");
			return items;
		}

		public async Task<List<TvSeriesSummary>?> GetTvSeriesList()
		{
			List<TvSeriesSummary>? items = await Client.GetFromJsonAsync<List<TvSeriesSummary>>($"PlexInfo/tvserieslist");
			return items;
		}

	}
}
