using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using smab.PlexInfo.Models;

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

		[HttpGet(Name = nameof(LibraryRoot))]
		public async Task<IActionResult> LibraryRoot()
		{
			var item = await _plexClient.GetLibraryRoot();
			return Ok(item);
		}

		[HttpGet(Name = nameof(LibrarySections))]
		public async Task<IActionResult> LibrarySections()
		{
			var items = await _plexClient.GetLibrarySections();
			return Ok(items);
		}

		[HttpGet(Name = nameof(AllMovies))]
		public async Task<IActionResult> AllMovies()
		{
			var items = await _plexClient.GetAllMovies();
			return Ok(items);
		}

		[HttpGet(Name = nameof(MoviesList))]
		public async Task<IActionResult> MoviesList()
		{
			var items = await _plexClient.GetAllMovies();
			// SelectMany flattens the returned structure to IEnumerable<MovieSummary>
			var itemsList = items.SelectMany(i => i.MediaContainer.Metadata?.Select(m =>
				new MovieSummary(
						LibraryId: i.MediaContainer.LibrarySectionID ?? 0,
						LibraryTitle: i.MediaContainer.LibrarySectionTitle ?? "",
						Id: int.Parse(m.Key.Replace(@"/library/metadata/", "").Replace(@"/children", "")),
						Title: m.Title,
						Year: m.Year,
						Duration: m.Duration ?? 0,
						Thumb: m.Thumb,
						AddedAt: m.AddedAt,
						Rating: m.Rating,
						OriginallyAvailableAt: m.OriginallyAvailableAt
					)) ?? new List<MovieSummary>());
			return Ok(itemsList);
		}

		[HttpGet(Name = nameof(TvShowsList))]
		public async Task<IActionResult> TvShowsList()
		{
			var items = await _plexClient.GetTvShows();
			// SelectMany flattens the returned structure to IEnumerable<TvSeriesSummary>
			var itemsList = items.SelectMany(i => i.MediaContainer.Metadata?.Select(m =>
				new TvShowSummary(
						LibraryId: i.MediaContainer.LibrarySectionID ?? 0,
						LibraryTitle: i.MediaContainer.LibrarySectionTitle ?? "",
						Id: int.Parse(m.Key.Replace(@"/library/metadata/", "").Replace(@"/children", "")),
						Title: m.Title,
						Year: m.Year,
						Duration: m.Duration ?? 0,
						Thumb: m.Thumb,
						Seasons: m.ChildCount ?? 0,
						Episodes: m.LeafCount ?? 0,
						ViewedEpisodes: m.ViewedLeafCount ?? 0,
						AddedAt: m.AddedAt,
						Rating: m.Rating,
						OriginallyAvailableAt: (m.OriginallyAvailableAt is not null) ? DateTime.Parse(m.OriginallyAvailableAt) : DateTime.MinValue
				)) ?? new List<TvShowSummary>());
			return Ok(itemsList);
		}

		[HttpGet("{id}", Name = nameof(Related))]
		public async Task<IActionResult> Related(int id)
		{
			var items = await _plexClient.GetRelated(id);
			return Ok(items);
		}

		[HttpGet("{id}", Name = nameof(Similar))]
		public async Task<IActionResult> Similar(int id)
		{
			var items = await _plexClient.GetSimilar(id);
			return Ok(items);
		}

		[HttpGet(Name = nameof(MovieCollections))]
		public async Task<IActionResult> MovieCollections()
		{
			var items = await _plexClient.GetMovieCollections();
			return Ok(items);
		}

		[HttpGet("{id}", Name = nameof(Item))]
		public async Task<IActionResult> Item(int id)
		{
			var item = await _plexClient.GetItem(id);
			if ((item is null) || (item.MediaContainer.Size == 0))
			{
				return NotFound(null);
			}
			return Ok(item);
		}

		[HttpGet("{id}", Name = nameof(ItemChildren))]
		public async Task<IActionResult> ItemChildren(int id)
		{
			var item = await _plexClient.GetItemChildren(id);
			if ((item is null) || (item.MediaContainer.Size == 0))
			{
				return NotFound(null);
			}
			return Ok(item);
		}

		[HttpGet(Name = nameof(Photo))]
		public async Task<IActionResult> Photo([FromQuery] string url, [FromQuery] int width = 180, [FromQuery] int height = 270)
		{
			byte[]? item = await _plexClient.GetPhotoFromUrl(url, width, height);
			if (item is null)
			{
				return NotFound(null);
			}
			return new FileContentResult(item, "image/jpeg");
		}

		[HttpGet("{resource}", Name = nameof(Resource))]
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
