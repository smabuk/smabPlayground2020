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
	[Route("[controller]/[action]")]
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
			var item = await _plexClient.GetLibraryRoot();
			return Ok(item);
		}

		[HttpGet]
		public async Task<IActionResult> LibrarySections()
		{
			var items = await _plexClient.GetLibrarySections();
			return Ok(items);
		}

		[HttpGet]
		public async Task<IActionResult> AllMovies()
		{
			var items = await _plexClient.GetAllMovies();
			return Ok(items);
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> Related(int id)
		{
			var items = await _plexClient.GetRelated(id);
			return Ok(items);
		}

		public async Task<IActionResult> MovieCollections()
		{
			var items = await _plexClient.GetMovieCollections();
			return Ok(items);
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
			var item = await _plexClient.GetItemChildren(id);
			if ((item is null) || (item.MediaContainer.Size == 0))
			{
				return NotFound(null);
			}
			return Ok(item);
		}

		[HttpGet]
		//[Route("{id}")]
		public async Task<IActionResult> Photo([FromQuery] string url, [FromQuery] int width = 180, [FromQuery] int height = 270)
		{
			byte[]? item = await _plexClient.GetPhotoFromUrl(url, width, height);
			if (item is null)
			{
				return NotFound(null);
			}
			return new FileContentResult(item, "image/jpeg");
		}

	}
}
