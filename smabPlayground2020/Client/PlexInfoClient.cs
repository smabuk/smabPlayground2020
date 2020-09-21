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

		public async Task<IList<ItemSummary>?> GetMoviesList()
		{
			IList<ItemSummary>? items = await Client.GetFromJsonAsync<IList<ItemSummary>>($"PlexInfo/movieslist");
			return items;
		}

	}
}
