using Microsoft.AspNetCore.Mvc;

namespace TheSecond.Areas.LandingPages.Controllers
{
    [Area("LandingPages")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
