using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class RentalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
