using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

using smabPlayground2020.Shared.Helpers;

namespace smab.PlexInfo.Models
{
	public record Metadata
    {

        [JsonPropertyName("historyKey")]
        public string? HistoryKey { get; init; }

        [JsonPropertyName("ratingKey")]
        public string RatingKey { get; init; }

        [JsonPropertyName("parentRatingKey")]
        public string? ParentRatingKey { get; init; }

        [JsonPropertyName("grandparentRatingKey")]
        public string? GrandparentRatingKey { get; init; }

        [JsonPropertyName("key")]
        public string Key { get; init; }

        [JsonPropertyName("parentKey")]
        public string? ParentKey { get; init; }

        [JsonPropertyName("grandparentKey")]
        public string? GrandparentKey { get; init; }

        [JsonPropertyName("guid")]
        public string Guid { get; init; }

        [JsonPropertyName("parentGuid")]
        public string? ParentGuid { get; init; }

        [JsonPropertyName("grandparentGuid")]
        public string? GrandparentGuid { get; init; }

        [JsonPropertyName("studio")]
        public string? Studio { get; init; }

        [JsonPropertyName("type")]
        public string Type { get; init; }

        [JsonPropertyName("subtype")]
        public string? SubType { get; init; }

        [JsonPropertyName("title")]
        public string Title { get; init; }

        [JsonPropertyName("parentTitle")]
        public string? ParentTitle { get; init; }

        [JsonPropertyName("grandparentTitle")]
        public string? GrandparentTitle { get; init; }

        [JsonPropertyName("librarySectionTitle")]
        public string? LibrarySectionTitle { get; init; }

        [JsonPropertyName("librarySectionID")]
        public int? LibrarySectionId { get; init; }

        [JsonPropertyName("librarySectionKey")]
        public string? LibrarySectionKey { get; init; }

        [JsonPropertyName("contentRating")]
        public string? ContentRating { get; init; }

        [JsonPropertyName("summary")]
        public string? Summary { get; init; }

        [JsonPropertyName("index")]
        public int? Index { get; init; }

        [JsonPropertyName("parentIndex")]
        public int? ParentIndex { get; init; }

        [JsonPropertyName("rating")]
        public double? Rating { get; init; }

        [JsonPropertyName("audienceRating")]
        public double? AudienceRating { get; init; }

        [JsonPropertyName("viewCount")]
        public int? ViewCount { get; init; }

        [JsonPropertyName("lastViewedAt")]
		[JsonConverter(typeof(JsonUnixDateConverterWithNulls))]
        public DateTime? LastViewedAt { get; init; }

        [JsonPropertyName("year")]
        public int? Year { get; init; }

        [JsonPropertyName("maxYear")]
        public int? MaxYear { get; init; }

        [JsonPropertyName("minYear")]
        public int? MinYear { get; init; }

        [JsonPropertyName("tagline")]
        public string? Tagline { get; init; }

        [JsonPropertyName("thumb")]
        public string? Thumb { get; init; }

        [JsonPropertyName("parentThumb")]
        public string? ParentThumb { get; init; }

        [JsonPropertyName("grandparentThumb")]
        public string? GrandparentThumb { get; init; }

        [JsonPropertyName("art")]
        public string? Art { get; init; }

        [JsonPropertyName("parentArt")]
        public string? ParentArt { get; init; }

        [JsonPropertyName("grandparentArt")]
        public string? GrandparentArt { get; init; }

        [JsonPropertyName("banner")]
        public string? Banner { get; init; }

        [JsonPropertyName("theme")]
        public string? Theme { get; init; }

        [JsonPropertyName("parentTheme")]
        public string? ParentTheme { get; init; }

        [JsonPropertyName("duration")]
        public int? Duration { get; init; }

        [JsonPropertyName("originallyAvailableAt")]
        public string? OriginallyAvailableAt { get; init; }

        [JsonPropertyName("leafCount")]
        public int? LeafCount { get; init; }

        [JsonPropertyName("viewedLeafCount")]
        public int? ViewedLeafCount { get; init; }

        [JsonPropertyName("childCount")]
        public int? ChildCount { get; init; }

        [JsonPropertyName("addedAt")]
		[JsonConverter(typeof(JsonUnixDateConverter))]
        public DateTime AddedAt { get; init; }

        [JsonPropertyName("updatedAt")]
		[JsonConverter(typeof(JsonUnixDateConverter))]
        public DateTime UpdatedAt { get; init; }

        [JsonPropertyName("audienceRatingImage")]
        public string? AudienceRatingImage { get; init; }

        [JsonPropertyName("chapterSource")]
        public string? ChapterSource { get; init; }

        [JsonPropertyName("primaryExtraKey")]
        public string? PrimaryExtraKey { get; init; }

        [JsonPropertyName("ratingImage")]
        public string? RatingImage { get; init; }

        [JsonPropertyName("accountID")]
        public int? AccountId { get; init; }

        [JsonPropertyName("deviceID")]
        public int? DeviceId { get; init; }





        [JsonPropertyName("Media")]
        public List<Medium>? Media { get; init; }

        [JsonPropertyName("Genre")]
        public List<Subitem>? Genres { get; init; }

        [JsonPropertyName("Director")]
        public List<Subitem>? Directors { get; init; }

        [JsonPropertyName("Writer")]
        public List<Subitem>? Writers { get; init; }

        [JsonPropertyName("Producer")]
        public List<Subitem>? Producers { get; init; }

        [JsonPropertyName("Country")]
        public List<Subitem>? Countries { get; init; }

        [JsonPropertyName("Role")]
        public List<RoleSubitem>? Roles { get; init; }

        [JsonPropertyName("Collection")]
        public List<Subitem>? Collections { get; init; }

        [JsonPropertyName("Similar")]
        public List<Subitem>? Similar { get; init; }

        [JsonPropertyName("Location")]
        public List<Location>? Locations { get; init; }


        public bool HasMedia => (Media is not null);
        public bool HasGenres => (Genres is not null);
        public bool HasDirectors => (Directors is not null);
        public bool HasWriters => (Writers is not null);
        public bool HasProducers => (Producers is not null);
        public bool HasCountries => (Countries is not null);
        public bool HasRoles => (Roles is not null);
        public bool HasCollections => (Collections is not null);
        public bool HasSimilar => (Similar is not null);
        public bool HasLocations => (Locations is not null);


	}
}
