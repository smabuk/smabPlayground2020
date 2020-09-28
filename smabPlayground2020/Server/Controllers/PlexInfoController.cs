using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

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
		public async Task<IActionResult> MoviesList()
		{
			var items = await _plexClient.GetAllMovies();
			// SelectMany flattens the returned structure to IEnumerable<MovieSummary>
			var itemsList = items.SelectMany(i => i.MediaContainer.Metadata?.Select(m =>
				new MovieSummary() { 
						LibraryId = i.MediaContainer.LibrarySectionId ?? 0,
						LibraryTitle = i.MediaContainer.LibrarySectionTitle ?? "",
						Id = int.Parse(m.Key.Replace(@"/library/metadata/", "").Replace(@"/children", "")),
						Title = m.Title,
						Year = m.Year,
						Duration = m.Duration ?? 0,
						Thumb = m.Thumb,
						AddedAt = m.AddedAt,
						Rating = m.Rating,
						OriginallyAvailableAt = m.OriginallyAvailableAt
					}) ?? new List<MovieSummary>());
			return Ok(itemsList);
		}

		[HttpGet]
		public async Task<IActionResult> TvSeriesList()
		{
			var items = await _plexClient.GetTvSeries();
			// SelectMany flattens the returned structure to IEnumerable<TvSeriesSummary>
			var itemsList = items.SelectMany(i => i.MediaContainer.Metadata?.Select(m =>
				new TvSeriesSummary() { 
						LibraryId = i.MediaContainer.LibrarySectionId ?? 0,
						LibraryTitle = i.MediaContainer.LibrarySectionTitle ?? "",
						Id = int.Parse(m.Key.Replace(@"/library/metadata/", "").Replace(@"/children", "")),
						Title = m.Title,
						Year = m.Year,
						Duration = m.Duration ?? 0,
						Thumb = m.Thumb,
						Seasons = m.ChildCount ?? 0,
						Episodes = m.LeafCount ?? 0,
						ViewedEpisodes = m.ViewedLeafCount ?? 0,
						AddedAt = m.AddedAt,
						Rating = m.Rating,
						OriginallyAvailableAt = (m.OriginallyAvailableAt is not null) ? DateTime.Parse(m.OriginallyAvailableAt) : DateTime.MinValue
				}) ?? new List<TvSeriesSummary>());
			return Ok(itemsList);
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
		public async Task<IActionResult> Photo([FromQuery] string url, [FromQuery] int width = 180, [FromQuery] int height = 270)
		{
			byte[]? item = await _plexClient.GetPhotoFromUrl(url, width, height);
			if (item is null)
			{
				return NotFound(null);
			}
			return new FileContentResult(item, "image/jpeg");
		}

		[HttpGet]
		[Route("{resource}")]
		public async Task<IActionResult> Resource(string resource)
		{
			byte[]? item = await _plexClient.GetResource(resource);
			if (item is null)
			{
				return NotFound(null);
			}
			return new FileContentResult(item, "image/png");
		}

	}
}
