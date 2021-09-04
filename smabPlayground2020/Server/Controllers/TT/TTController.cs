using Microsoft.AspNetCore.Mvc;

using smab.TT;

namespace smabPlayground2020.Server.Controllers.TT;

[Route("/TT/[action]")]
public partial class TTController : Controller {
	private readonly ITT365Service _tt365;
	private readonly IWebHostEnvironment _env;
	private readonly IConfiguration _config;
	private readonly ILogger _logger;

	public TTController(
		ITT365Service tT365Service,
		IWebHostEnvironment env,
		ILogger<TTController> logger,
		IConfiguration config
		) {
		_tt365 = tT365Service;
		_env = env;
		_logger = logger;
		_config = config;
	}

	public IActionResult Index() {
		return View();
	}
}
