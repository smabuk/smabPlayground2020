﻿using System.Collections.Generic;

namespace smab.PlexInfo.Models {
	public record Hub
	(
		string HubKey,
		string Key,
		string Title,
		string Type,
		string HubIdentifier,
		string Context,
		int Size,
		bool More,
		string Style,
		List<Metadata>? Metadata
	);
}
