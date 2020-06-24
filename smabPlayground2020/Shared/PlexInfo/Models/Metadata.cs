using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

using smabPlayground2020.Shared.Helpers;

namespace smabPlayground2020.Shared.PlexInfo.Models
{
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    public class Metadata
    {

        [JsonPropertyName("historyKey")]
        public string? HistoryKey { get; set; }

        [JsonPropertyName("ratingKey")]
        public string RatingKey { get; set; }

        [JsonPropertyName("parentRatingKey")]
        public string? ParentRatingKey { get; set; }

        [JsonPropertyName("grandparentRatingKey")]
        public string? GrandparentRatingKey { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("parentKey")]
        public string? ParentKey { get; set; }

        [JsonPropertyName("grandparentKey")]
        public string? GrandparentKey { get; set; }

        [JsonPropertyName("guid")]
        public string Guid { get; set; }

        [JsonPropertyName("parentGuid")]
        public string? ParentGuid { get; set; }

        [JsonPropertyName("grandparentGuid")]
        public string? GrandparentGuid { get; set; }

        [JsonPropertyName("studio")]
        public string? Studio { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("subtype")]
        public string? SubType { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("parentTitle")]
        public string? ParentTitle { get; set; }

        [JsonPropertyName("grandparentTitle")]
        public string? GrandparentTitle { get; set; }

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

        [JsonPropertyName("parentIndex")]
        public int? ParentIndex { get; set; }

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

        [JsonPropertyName("parentThumb")]
        public string? ParentThumb { get; set; }

        [JsonPropertyName("grandparentThumb")]
        public string? GrandparentThumb { get; set; }

        [JsonPropertyName("art")]
        public string? Art { get; set; }

        [JsonPropertyName("parentArt")]
        public string? ParentArt { get; set; }

        [JsonPropertyName("grandparentArt")]
        public string? GrandparentArt { get; set; }

        [JsonPropertyName("banner")]
        public string? Banner { get; set; }

        [JsonPropertyName("theme")]
        public string? Theme { get; set; }

        [JsonPropertyName("parentTheme")]
        public string? ParentTheme { get; set; }

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

        [JsonPropertyName("accountID")]
        public int? AccountId { get; set; }

        [JsonPropertyName("deviceID")]
        public int? DeviceId { get; set; }





        [JsonPropertyName("Media")]
        public IList<Medium>? Media { get; set; }

        [JsonPropertyName("Genre")]
        public IList<Subitem>? Genres { get; set; }

        [JsonPropertyName("Director")]
        public IList<Subitem>? Directors { get; set; }

        [JsonPropertyName("Writer")]
        public IList<Subitem>? Writers { get; set; }

        [JsonPropertyName("Producer")]
        public IList<Subitem>? Producers { get; set; }

        [JsonPropertyName("Country")]
        public IList<Subitem>? Countries { get; set; }

        [JsonPropertyName("Role")]
        public IList<RoleSubitem>? Roles { get; set; }

        [JsonPropertyName("Collection")]
        public IList<Subitem>? Collections { get; set; }

        [JsonPropertyName("Similar")]
        public IList<Subitem>? Similar { get; set; }

        [JsonPropertyName("Location")]
        public IList<Location>? Locations { get; set; }
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

}
