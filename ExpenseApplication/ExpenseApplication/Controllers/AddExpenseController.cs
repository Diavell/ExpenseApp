using ExpenseApplication.Models;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenseApplication.Controllers
{
    public class AddExpenseController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Size = new SelectList(
             new List<SelectListItem> {
             new SelectListItem { Text="TL", Value = "TL"},
             new SelectListItem { Text="EUR", Value = "EUR"},
             new SelectListItem { Text="USD", Value = "USD"},
             new SelectListItem { Text="PKR", Value = "PKR"},
             new SelectListItem { Text="INR", Value = "INR"}
             }, "Value", "Text");
            return View();
        }

        public int SaveExpense(AddExpense expense)
        {
            using (var ctx = new ExpenseDataEntities7())
            {
                ctx.AddExpense.Add(expense);
                return ctx.SaveChanges();
            }
        }
        [HttpPost]
        public ActionResult Add(AddExpense expense)
        {
            expense.userId = (int)TempData["Id"];
            expense.expenseApproval = "Beklemede";
            SaveExpense(expense);
            return RedirectToAction("Index", "Home");
        }
    }
}