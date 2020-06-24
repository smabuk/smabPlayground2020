using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smabPlayground2020.Shared.PlexInfo.Models
{
	public static class MediaTypes
	{
		public static IList<MediaType> Collection => new List<MediaType> {
			new MediaType() { Id = 1, TypeString = "movie", Title = "Movie", Element = "video"},
			new MediaType() { Id = 2, TypeString = "show", Title = "Show", Element = "directory",
				Related = new List<int> {3, 4}  },
			new MediaType() { Id = 3, TypeString = "season", Title = "Season", Element = "directory",
				Related = new List<int> {2, 4}  },
			new MediaType() { Id = 4, TypeString = "episode", Title = "Episode", Element = "video",
				Related = new List<int> {2, 3}  },
			new MediaType() { Id = 5, TypeString = "trailer", Title = "Trailer", Element = "video"},
			new MediaType() { Id = 6, TypeString = "comic", Title = "Comic", Element = "photo"},
			new MediaType() { Id = 7, TypeString = "person", Title = "Person", Element = "directory"},
			new MediaType() { Id = 8, TypeString = "artist", Title = "Artist", Element = "directory",
				Related = new List<int> {9, 10}  },
			new MediaType() { Id = 9, TypeString = "album", Title = "Album", Element = "directory",
				Related = new List<int> {8, 10}  },
			new MediaType() { Id = 10, TypeString = "track", Title = "Track", Element = "audio",
				Related = new List<int> {8, 9}  },
			new MediaType() { Id = 11, TypeString = "photoAlbum", Title = "Photo Album", Element = "directory",
				Related = new List<int> {12, 13}  },
			new MediaType() { Id = 12, TypeString = "picture", Title = "Picture", Element = "photo",
				Related = new List<int> {11}  },
			new MediaType() { Id = 13, TypeString = "photo", Title = "Photo", Element = "photo",
				Related = new List<int> {11}  },
			new MediaType() { Id = 14, TypeString = "clip", Title = "Clip", Element = "video"},
			new MediaType() { Id = 15, TypeString = "playlistItem", Title="Clip", Element="video"}
		};
	}

#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
	public class MediaType
	{
		public int Id { get; set; }
		public string TypeString { get; set; }
		public string Title { get; set; }
		public string Element { get; set; }
		public IList<int>? Related { get; set; }
	}
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
}
