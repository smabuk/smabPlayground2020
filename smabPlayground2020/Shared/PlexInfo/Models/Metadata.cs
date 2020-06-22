using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

using smabPlayground2020.Shared.Helpers;

namespace smabPlayground2020.Shared.PlexInfo.Models
{
	public class Metadata
    {

        [JsonPropertyName("ratingKey")]
        public string RatingKey { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("guid")]
        public string Guid { get; set; }

        [JsonPropertyName("studio")]
        public string? Studio { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("subtype")]
        public string? SubType { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("librarySectionTitle")]
        public string? LibrarySectionTitle { get; set; }

        [JsonPropertyName("librarySectionID")]
        public int? LibrarySectionId { get; set; }

        [JsonPropertyName("librarySectionKey")]
        public string? LibrarySectionKey { get; set; }

        [JsonPropertyName("contentRating")]
        public string? ContentRating { get; set; }

        [JsonPropertyName("summary")]
        public string? Summary { get; set; }

        [JsonPropertyName("index")]
        public int? Index { get; set; }

        [JsonPropertyName("rating")]
        public double? Rating { get; set; }

        [JsonPropertyName("audienceRating")]
        public double? AudienceRating { get; set; }

        [JsonPropertyName("viewCount")]
        public int? ViewCount { get; set; }

        [JsonPropertyName("lastViewedAt")]
		[JsonConverter(typeof(JsonUnixDateConverterWithNulls))]
        public DateTime? LastViewedAt { get; set; }

        [JsonPropertyName("year")]
        public int? Year { get; set; }

        [JsonPropertyName("maxYear")]
        public int? MaxYear { get; set; }

        [JsonPropertyName("minYear")]
        public int? MinYear { get; set; }

        [JsonPropertyName("tagline")]
        public string? Tagline { get; set; }

        [JsonPropertyName("thumb")]
        public string? Thumb { get; set; }

        [JsonPropertyName("art")]
        public string? Art { get; set; }

        [JsonPropertyName("banner")]
        public string? Banner { get; set; }

        [JsonPropertyName("theme")]
        public string? Theme { get; set; }

        [JsonPropertyName("duration")]
        public int? Duration { get; set; }

        [JsonPropertyName("originallyAvailableAt")]
        public string? OriginallyAvailableAt { get; set; }

        [JsonPropertyName("leafCount")]
        public int? LeafCount { get; set; }

        [JsonPropertyName("viewedLeafCount")]
        public int? ViewedLeafCount { get; set; }

        [JsonPropertyName("childCount")]
        public int? ChildCount { get; set; }

        [JsonPropertyName("addedAt")]
		[JsonConverter(typeof(JsonUnixDateConverter))]
        public DateTime AddedAt { get; set; }

        [JsonPropertyName("updatedAt")]
		[JsonConverter(typeof(JsonUnixDateConverter))]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("audienceRatingImage")]
        public string? AudienceRatingImage { get; set; }

        [JsonPropertyName("chapterSource")]
        public string? ChapterSource { get; set; }

        [JsonPropertyName("primaryExtraKey")]
        public string? PrimaryExtraKey { get; set; }

        [JsonPropertyName("ratingImage")]
        public string? RatingImage { get; set; }



        [JsonPropertyName("Media")]
        public IEnumerable<Medium>? Media { get; set; }

        [JsonPropertyName("Genre")]
        public IEnumerable<Subitem>? Genres { get; set; }

        [JsonPropertyName("Director")]
        public IEnumerable<Subitem>? Directors { get; set; }

        [JsonPropertyName("Writer")]
        public IEnumerable<Subitem>? Writers { get; set; }

        [JsonPropertyName("Producer")]
        public IEnumerable<Subitem>? Producers { get; set; }

        [JsonPropertyName("Country")]
        public IEnumerable<Subitem>? Countries { get; set; }

        [JsonPropertyName("Role")]
        public IEnumerable<RoleSubitem>? Roles { get; set; }

        [JsonPropertyName("Collection")]
        public IEnumerable<Subitem>? Collections{ get; set; }

        [JsonPropertyName("Similar")]
        public IEnumerable<Subitem>? Similar { get; set; }

        [JsonPropertyName("Location")]
        public IEnumerable<Location>? Location { get; set; }
    }

}
