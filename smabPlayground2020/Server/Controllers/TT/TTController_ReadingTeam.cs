using Microsoft.AspNetCore.Mvc;

using smab.TT;
using smab.TT.Models;


namespace smabPlayground2020.Server.Controllers.TT {
	public partial class TTController : Controller {

		[HttpGet]
		[Route("{TeamName}")]
		public async Task<IActionResult> ReadingTeam(String TeamName = "") {
			TeamName = TeamName.Replace("_", " ");
			TT365Models.ReadingTeam model = new TT365Models.ReadingTeam  (
				 await TT365ReaderHelper.GetTeam(_tt365, TeamName),
				 await _tt365.GetFixturesAdvancedView(TeamName) ?? new()
			);

			return Ok(model);
		}

	}
}
