using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

using smabPlayground2020.Shared.Helpers;

namespace smab.PlexInfo.Models {
	public record Metadata
	(
		string? HistoryKey,
		string RatingKey,
		string? ParentRatingKey,
		string? GrandparentRatingKey,
		string Key,
		string? ParentKey,
		string? GrandparentKey,
		// There are now 2 values "guid" and "Guid" the latter of which is an array
		// string Guid,
		string? ParentGuid,
		string? GrandparentGuid,
		string? Studio,
		string Type,
		string? SubType,
		string Title,
		string? ParentTitle,
		string? GrandparentTitle,
		string? LibrarySectionTitle,
		int? LibrarySectionId,
		string? LibrarySectionKey,
		string? ContentRating,
		string? Summary,
		int? Index,
		int? ParentIndex,
		double? Rating,
		double? AudienceRating,
		int? ViewCount,
		int? Year,
		int? MaxYear,
		int? MinYear,
		string? Tagline,
		string? Thumb,
		string? ParentThumb,
		string? GrandparentThumb,
		string? Art,
		string? ParentArt,
		string? GrandparentArt,
		string? Banner,
		string? Theme,
		string? ParentTheme,
		int? Duration,
		string? OriginallyAvailableAt,
		int? LeafCount,
		int? ViewedLeafCount,
		int? ChildCount,
		string? AudienceRatingImage,
		string? ChapterSource,
		string? PrimaryExtraKey,
		string? RatingImage,
		int? AccountId,
		List<Medium>? Media,
		List<Subitem>? Genre,
		List<Subitem>? Director,
		List<Subitem>? Writer,
		List<Subitem>? Producer,
		List<Subitem>? Country,
		List<RoleSubitem>? Role,
		List<Subitem>? Collection,
		List<Subitem>? Similar,
		List<Location>? Location
	) {

		[JsonPropertyName("addedAt")]
		[JsonConverter(typeof(JsonUnixDateConverter))]
		public DateTime AddedAt { get; init; }

		[JsonPropertyName("updatedAt")]
		[JsonConverter(typeof(JsonUnixDateConverter))]
		public DateTime UpdatedAt { get; init; }

		[JsonPropertyName("lastViewedAt")]
		[JsonConverter(typeof(JsonUnixDateConverterWithNulls))]
		public DateTime? LastViewedAt { get; init; }

		public bool HasMedia => (Media is not null);
		public bool HasGenres => (Genre is not null);
		public bool HasDirectors => (Director is not null);
		public bool HasWriters => (Writer is not null);
		public bool HasProducers => (Producer is not null);
		public bool HasCountries => (Country is not null);
		public bool HasRoles => (Role is not null);
		public bool HasCollections => (Collection is not null);
		public bool HasSimilar => (Similar is not null);
		public bool HasLocations => (Location is not null);


	};
}
