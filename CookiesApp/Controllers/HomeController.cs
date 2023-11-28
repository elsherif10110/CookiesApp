using CookiesApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CookiesApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            DbCookiesContext ctx= new DbCookiesContext();
            var UserAuthentications = ctx.TbUserAuthentication.ToList();
            return View(UserAuthentications);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}