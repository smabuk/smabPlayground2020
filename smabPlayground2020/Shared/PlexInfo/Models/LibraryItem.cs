using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using smabPlayground2020.Shared.Helpers;

namespace smabPlayground2020.Shared.PlexInfo.Models
{
    public class LibraryItem
    {

        [JsonPropertyName("MediaContainer")]
        public ItemMediaContainer MediaContainer { get; set; } = new ItemMediaContainer();
    }

    public class ItemMediaContainer
    {

        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("allowSync")]
        public bool AllowSync { get; set; }

        [JsonPropertyName("identifier")]
        public string Identifier { get; set; } = "";

        [JsonPropertyName("librarySectionID")]
        public int LibrarySectionID { get; set; }

        [JsonPropertyName("librarySectionTitle")]
        public string LibrarySectionTitle { get; set; } = "";

        [JsonPropertyName("librarySectionUUID")]
        public string LibrarySectionUUID { get; set; } = "";

        [JsonPropertyName("mediaTagPrefix")]
        public string MediaTagPrefix { get; set; } = "";

        [JsonPropertyName("mediaTagVersion")]
        public int MediaTagVersion { get; set; }

        [JsonPropertyName("Metadata")]
        public IList<ItemMetadata> Metadata { get; set; }
    }

    public class ItemLocation
    {

        [JsonPropertyName("path")]
        public string Path { get; set; } = "";
    }

    public class ItemMetadata
    {

        [JsonPropertyName("ratingKey")]
        public string RatingKey { get; set; } = "";

        [JsonPropertyName("key")]
        public string Key { get; set; } = "";

        [JsonPropertyName("guid")]
        public string Guid { get; set; } = "";

        [JsonPropertyName("studio")]
        public string Studio { get; set; } = "";

        [JsonPropertyName("type")]
        public string Type { get; set; } = "";

        [JsonPropertyName("title")]
        public string Title { get; set; } = "";

        [JsonPropertyName("librarySectionTitle")]
        public string LibrarySectionTitle { get; set; } = "";

        [JsonPropertyName("librarySectionID")]
        public int LibrarySectionID { get; set; }

        [JsonPropertyName("librarySectionKey")]
        public string LibrarySectionKey { get; set; } = "";

        [JsonPropertyName("contentRating")]
        public string ContentRating { get; set; } = "";

        [JsonPropertyName("summary")]
        public string Summary { get; set; } = "";

        [JsonPropertyName("index")]
        public int Index { get; set; }

        [JsonPropertyName("rating")]
        public double Rating { get; set; }

        [JsonPropertyName("viewCount")]
        public int ViewCount { get; set; }

        [JsonPropertyName("lastViewedAt")]
		[JsonConverter(typeof(JsonUnixDateConverter))]
        public DateTime LastViewedAt { get; set; }

        [JsonPropertyName("year")]
        public int Year { get; set; }

        [JsonPropertyName("thumb")]
        public string Thumb { get; set; } = "";

        [JsonPropertyName("art")]
        public string Art { get; set; } = "";

        [JsonPropertyName("banner")]
        public string Banner { get; set; } = "";

        [JsonPropertyName("theme")]
        public string Theme { get; set; } = "";

        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        [JsonPropertyName("originallyAvailableAt")]
        public string OriginallyAvailableAt { get; set; } = "";

        [JsonPropertyName("leafCount")]
        public int LeafCount { get; set; }

        [JsonPropertyName("viewedLeafCount")]
        public int ViewedLeafCount { get; set; }

        [JsonPropertyName("childCount")]
        public int ChildCount { get; set; }

        [JsonPropertyName("addedAt")]
		[JsonConverter(typeof(JsonUnixDateConverter))]
        public DateTime AddedAt { get; set; }

        [JsonPropertyName("updatedAt")]
		[JsonConverter(typeof(JsonUnixDateConverter))]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("Genre")]
        public IList<ItemGenre> Genre { get; set; }

        [JsonPropertyName("Role")]
        public IList<ItemRole> Role { get; set; }

        [JsonPropertyName("Similar")]
        public IList<Similar> Similar { get; set; }

        [JsonPropertyName("Location")]
        public IList<ItemLocation> Location { get; set; }
    }

    public class ItemGenre
    {

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("filter")]
        public string Filter { get; set; } = "";

        [JsonPropertyName("tag")]
        public string Tag { get; set; } = "";
    }

    public class ItemRole
    {

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("filter")]
        public string Filter { get; set; } = "";

        [JsonPropertyName("tag")]
        public string Tag { get; set; } = "";

        [JsonPropertyName("role")]
        public string Role { get; set; } = "";

        [JsonPropertyName("thumb")]
        public string Thumb { get; set; } = "";
    }

    public class Similar
    {

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("filter")]
        public string Filter { get; set; } = "";

        [JsonPropertyName("tag")]
        public string Tag { get; set; } = "";
    }

}
