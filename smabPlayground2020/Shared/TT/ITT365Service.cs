using smab.TT.Models;

namespace smab.TT;

public interface ITT365Service
{
	string Season { get; set; }

	Task<TT365Models.FixturesView?> GetFixturesAdvancedView(string TeamName = "");
	Task<TT365Models.Team?> GetTeamStats(string TeamName);

}
