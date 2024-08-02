using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class KashidasiController : Controller
    {

        private readonly ILogger<KashidasiController> _logger;

        public KashidasiController(ILogger<KashidasiController> logger)
        {
            _logger = logger;
        }
        public IActionResult Mainmenu()
        {
            return View();
        }
        public IActionResult Device()
        {
            return View();
        }

        public IActionResult User()
        {
            return View();
        }
        public IActionResult Rental()
        {
            return View();
        }
    }
}
