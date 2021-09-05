using System.Net.Http.Json;

using smab.TT.Models;

namespace smabPlayground2020.Client;

public class TT365Client
{
	public HttpClient Client { get; }

	public TT365Client(HttpClient httpClient)
	{
		Client = httpClient;
	}

	public async Task<TT365Models.ReadingTeam?> GetReadingTeam(string TeamName)
	{
		TT365Models.ReadingTeam? team = await Client.GetFromJsonAsync<TT365Models.ReadingTeam?>($"api/tt/readingteam/{TeamName}");
		return team;
	}

}
