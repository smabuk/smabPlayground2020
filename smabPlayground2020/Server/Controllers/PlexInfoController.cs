using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

using AutoMapper.Configuration;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using smabPlayground2020.Shared.PlexInfo;
using smabPlayground2020.Shared.PlexInfo.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace smabPlayground2020.Server.Controllers
{
	[ApiController]
	[Route("api/[controller]/[action]")]
	public class PlexInfoController : ControllerBase
	{
		private readonly IHttpClientFactory clientFactory;
		//private readonly HttpClient client;
		private readonly PlexSettings plexSettings;
		public string BaseUri { get; set; } = "";
		public string Token { get; set; } = "";

		public PlexInfoController(IOptions<PlexSettings> options, IHttpClientFactory ClientFactory)
		{
			clientFactory = ClientFactory;
			//client = ClientFactory.CreateClient("Plex");
			plexSettings = options.Value;
			BaseUri = plexSettings.Server;
			Token = plexSettings.Token;	
		}

		[HttpGet]
		public async Task<IActionResult> LibraryRoot()
		{
			HttpClient client = clientFactory.CreateClient("Plex");
			string rawJson = await client.GetStringAsync($"library?X-Plex-Token={Token}");
			return Ok(JsonSerializer.Deserialize<LibraryRoot>(rawJson));
		}

		[HttpGet]
		public async Task<IActionResult> LibrarySections()
		{
			HttpClient client = clientFactory.CreateClient("Plex");
			string rawJson = await client.GetStringAsync($"library/sections?X-Plex-Token={Token}");
			return Ok(JsonSerializer.Deserialize<LibrarySections>(rawJson));
		}

		[HttpGet]
		public async Task<IActionResult> AllMovies()
		{
			HttpClient client = clientFactory.CreateClient("Plex");
			string rawJson = await client.GetStringAsync($"library/sections/3/all?X-Plex-Token={Token}&includeCollections=0&sort=titleSort");
			return Ok(JsonSerializer.Deserialize<LibraryMovies>(rawJson));
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> Item(int id)
		{
			HttpClient client = clientFactory.CreateClient("Plex");
			string rawJson = await client.GetStringAsync($"library/metadata/{id}?X-Plex-Token={Token}");
			LibraryItem libraryItem = JsonSerializer.Deserialize<LibraryItem>(rawJson);
			return Ok(libraryItem);
		}

	}
}
