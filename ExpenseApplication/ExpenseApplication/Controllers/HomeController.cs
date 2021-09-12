using ExpenseApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenseApplication.Controllers
{
    [Audit]
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        //[Authorize(Roles = "1")]
        public ActionResult Add()
        {
            return RedirectToAction("Add", "AddExpense");
        }

        public ActionResult List()
        {
            return RedirectToAction("List", "ListExpense");
        }

        public ActionResult Accountant()
        {
            return RedirectToAction("AccountantList", "Accountant");
        }

        public ActionResult Manager()
        {
            return RedirectToAction("ManagerList", "Manager");
        }
    }
}