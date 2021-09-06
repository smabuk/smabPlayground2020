using Microsoft.AspNetCore.Mvc;

using smab.TT;
using smab.TT.Models;

using static smab.TT.Models.TT365Models;

namespace smabPlayground2020.Server.Controllers.TT;

[Route("/api/TT/[action]")]
public partial class TTController : Controller {
	private readonly ITT365Service _tt365;

	public TTController(ITT365Service tt365Service) {
		_tt365 = tt365Service;
	}


	[HttpGet]
	[Route("{TeamName}")]
	public async Task<IActionResult> ReadingTeam(String TeamName) {
		TeamName = TeamName.Replace("_", " ");
		TT365Models.ReadingTeam model = new TT365Models.ReadingTeam(
			 await TT365ReaderHelper.GetTeam(_tt365, TeamName),
			 await _tt365.GetFixturesAdvancedView(TeamName) ?? new()
		);

		return Ok(model);
	}


	[HttpGet]
	[Route("{TeamName}")]
	public async Task<IActionResult> Fixtures(String TeamName = "") {
		TeamName = TeamName.Replace("_", " ");
		TT365Models.FixturesView list = await _tt365.GetFixturesAdvancedView(TeamName) ?? new();

		return Ok(list);
	}

	[HttpGet]
	[Route("{TeamName}")]
	public async Task<IActionResult> Team(String TeamName) {
		TeamName = TeamName.Replace("_", " ");

		TT365Models.Team? team = await _tt365.GetTeamStats(TeamName);
		if (team is null) {
			return NotFound();
		}

		return Ok(team);
	}

	[HttpGet]
	[Route("{TeamName}")]
	public async Task<IActionResult> TeamPlayersList(String TeamName) {
		TeamName = TeamName.Replace("_", " ");

		TT365Models.Team? team = await _tt365.GetTeamStats(TeamName);
		if (team is null) {
			return NotFound();
		}
		List<string>? teamplayers = (from p in team.Players
									 select p.Name + " (" + p.WinPercentage + ")").ToList();
		return Ok(teamplayers);
	}




}
