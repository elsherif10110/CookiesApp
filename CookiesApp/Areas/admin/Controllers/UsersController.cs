using Microsoft.AspNetCore.Mvc;
using CookiesApp.Models;

namespace CookiesApp.Areas.admin.Controllers
{
    [Area("admin")]

    public class UsersController : Controller
    {
        public IActionResult List()
        {
            DbCookiesContext dbCookiesContext = new DbCookiesContext();
            var listUsers = dbCookiesContext.TbUserAuthentication.ToList();
            return View(listUsers);
        }
        public IActionResult Edit()
        {
            //DbCookiesContext dbCookiesContext = new DbCookiesContext();
            //var listUsers = dbCookiesContext.TbUserAuthentications.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(TbUserAuthentication users)
        {
            if (!ModelState.IsValid)

            return View("Edit", users);
            DbCookiesContext dbCookiesContext = new DbCookiesContext();
            users.UserId = 1;
            users.Birthdate = DateTime.Now;
            dbCookiesContext.TbUserAuthentication.Add(users);
            dbCookiesContext.SaveChanges();

            return RedirectToAction("Edit");
        }

    }
}
