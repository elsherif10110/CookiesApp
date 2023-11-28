using Microsoft.AspNetCore.Mvc;
using CookiesApp.Models;
using System.Diagnostics;


namespace CookiesApp.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View("Register");
        }

    }
}
