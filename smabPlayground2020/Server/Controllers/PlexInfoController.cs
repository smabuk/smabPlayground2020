using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

using AutoMapper.Configuration;

using Microsoft.AspNetCore.Mvc;

using smabPlayground2020.Shared.PlexInfo;
using smabPlayground2020.Shared.PlexInfo.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace smabPlayground2020.Server.Controllers
{
	[ApiController]
	[Route("api/[controller]/[action]")]
	public class PlexInfoController : ControllerBase
	{
		private readonly IPlexClient _plexClient;

		public PlexInfoController(IPlexClient plexClient)
		{
			_plexClient = plexClient;
		}

		[HttpGet]
		public async Task<IActionResult> LibraryRoot()
		{
			var libraryRoot = await _plexClient.GetLibraryRoot();
			return Ok(libraryRoot);
		}

		[HttpGet]
		public async Task<IActionResult> LibrarySections()
		{
			var librarySections = await _plexClient.GetLibrarySections();
			return Ok(librarySections);
		}

		[HttpGet]
		public async Task<IActionResult> AllMovies()
		{
			var allMovies = await _plexClient.GetAllMovies();
			return Ok(allMovies);
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> Item(int id)
		{
			var item = await _plexClient.GetItem(id);
			if ((item is null) || (item.MediaContainer.Size == 0))
			{
				return NotFound(null);
			}
			return Ok(item);
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> ItemChildren(int id)
		{
			var item = await _plexClient.GetItem(id);
			if ((item is null) || (item.MediaContainer.Size == 0))
			{
				return NotFound(null);
			}
			return Ok(item);
		}

	}
}
