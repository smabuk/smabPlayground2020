using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace smabPlayground2020.Shared.PlexInfo.Models
{
	public class LibraryMovies
	{
		[JsonPropertyName("MediaContainer")]
		public MoviesMediaContainer MediaContainer { get; set; } = new MoviesMediaContainer();
	}

	public class MoviesMediaContainer
	{
		public int size { get; set; }
		public bool allowSync { get; set; }
		public string art { get; set; }
		public string identifier { get; set; }
		public int librarySectionID { get; set; }
		public string librarySectionTitle { get; set; }
		public string librarySectionUUID { get; set; }
		public string mediaTagPrefix { get; set; }
		public int mediaTagVersion { get; set; }
		public string thumb { get; set; }
		public string title1 { get; set; }
		public string title2 { get; set; }
		public string viewGroup { get; set; }
		public int viewMode { get; set; }
		public Metadata[] Metadata { get; set; }
	}

	public class Metadata
	{
		public string ratingKey { get; set; }
		public string key { get; set; }
		public string guid { get; set; }
		public string type { get; set; }
		public string title { get; set; }
		public string subtype { get; set; }
		public string summary { get; set; }
		public int index { get; set; }
		public string thumb { get; set; }
		public int addedAt { get; set; }
		public int updatedAt { get; set; }
		public string childCount { get; set; }
		public string maxYear { get; set; }
		public string minYear { get; set; }
		public string contentRating { get; set; }
		public float rating { get; set; }
		public int year { get; set; }
		public string art { get; set; }
		public int duration { get; set; }
		public string originallyAvailableAt { get; set; }
		public string chapterSource { get; set; }
		public string primaryExtraKey { get; set; }
		public string ratingImage { get; set; }
		public Medium[] Media { get; set; }
		public ItemGenre[] Genre { get; set; }
		public Director[] Director { get; set; }
		public Writer[] Writer { get; set; }
		public Country[] Country { get; set; }
		public Role[] Role { get; set; }
		public string studio { get; set; }
		public float audienceRating { get; set; }
		public string tagline { get; set; }
		public string audienceRatingImage { get; set; }
		public int viewCount { get; set; }
		public int lastViewedAt { get; set; }
		public Collection[] Collection { get; set; }
		public string titleSort { get; set; }
		public string originalTitle { get; set; }
		public float userRating { get; set; }
		public int lastRatedAt { get; set; }
	}

	public class Medium
	{
		public int id { get; set; }
		public int duration { get; set; }
		public int bitrate { get; set; }
		public int width { get; set; }
		public int height { get; set; }
		public float aspectRatio { get; set; }
		public int audioChannels { get; set; }
		public string audioCodec { get; set; }
		public string videoCodec { get; set; }
		public string videoResolution { get; set; }
		public string container { get; set; }
		public string videoFrameRate { get; set; }
		public string videoProfile { get; set; }
		public Part[] Part { get; set; }
		public int optimizedForStreaming { get; set; }
		public string audioProfile { get; set; }
		public bool has64bitOffsets { get; set; }
	}

	public class Part
	{
		public int id { get; set; }
		public string key { get; set; }
		public int duration { get; set; }
		public string file { get; set; }
		public long size { get; set; }
		public string container { get; set; }
		public string videoProfile { get; set; }
		public string audioProfile { get; set; }
		public bool has64bitOffsets { get; set; }
		public bool optimizedForStreaming { get; set; }
		public string hasThumbnail { get; set; }
	}

	public class Genre
	{
		public string tag { get; set; }
	}

	public class Director
	{
		public string tag { get; set; }
	}

	public class Writer
	{
		public string tag { get; set; }
	}

	public class Country
	{
		public string tag { get; set; }
	}

	public class Role
	{
		public string tag { get; set; }
	}

	public class Collection
	{
		public string tag { get; set; }
	}

}
