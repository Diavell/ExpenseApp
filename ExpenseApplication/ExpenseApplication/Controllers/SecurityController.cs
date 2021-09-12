using ExpenseApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ExpenseApplication.Controllers
{
    [AllowAnonymous]
    public class SecurityController : Controller
    {
        ExpenseDataEntities7 db = new ExpenseDataEntities7();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var userInDb = db.User.FirstOrDefault(x => x.userName == user.userName && x.password == user.password);
            if (userInDb != null)
            {
                FormsAuthentication.SetAuthCookie(user.userName, false);
                TempData["Id"] = userInDb.userId;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Mesaj = "User or password incorrect";
                return View();
            }
        }
    }

    
}