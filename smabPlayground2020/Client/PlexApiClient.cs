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
	public class PlexApiClient
	{
		public HttpClient Client { get; }

		public PlexApiClient(HttpClient httpClient)
		{
			Client = httpClient;
		}

		public async Task<LibraryItem> GetItem(int id)
		{
			LibraryItem item = await Client.GetFromJsonAsync<LibraryItem>($"api/PlexInfo/item/{id}");
			return item;
		}

	}
}
