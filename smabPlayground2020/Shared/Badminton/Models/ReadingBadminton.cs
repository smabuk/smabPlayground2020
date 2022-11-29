using System.Diagnostics;

namespace Smab.ReadingBadminton.Models;

public class ReadingFixtures {
	public List<Fixture>? Fixtures { get; set; }
}

[DebuggerDisplay("Fixture: {Date,nq} - {HomeTeam,nq} vs {AwayTeam,nq}")]
public class Fixture {
	public string Division { get; set; } = "";
	public string Description { get; set; } = "";
	public DateTime When { get; set; }
	public string HomeTeam { get; set; } = "";
	public string AwayTeam { get; set; } = "";
	public string Venue { get; set; } = "";
	public bool IsCompleted { get; set; } = false;
	public int ForHome { get; set; }
	public int ForAway { get; set; }
	public string CardURL { get; set; } = "";

	public string Score {
		get {
			if (IsCompleted)
				return ForHome + " - " + ForAway;
			return string.Empty;
		}
	}
}

