using Microsoft.AspNetCore.Mvc;

namespace CookiesApp.Controllers
{
    public class UsersControllers : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
