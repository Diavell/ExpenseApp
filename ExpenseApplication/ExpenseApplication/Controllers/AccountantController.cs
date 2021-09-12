using ExpenseApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenseApplication.Controllers
{
    public class AccountantController : Controller
    {
        ExpenseDataEntities7 db = new ExpenseDataEntities7();

        public ActionResult AccountantList()
        {
            return View(db.AddExpense.Where(x => x.expenseApproval == "Onaylandı").ToList());
        }

        public ActionResult Edit(int id)
        {
            var expense = db.AddExpense.Where(x => x.expenseId == id).FirstOrDefault();
            expense.expenseApproval = "Ödendi";
            db.SaveChanges();
            return RedirectToAction("AccountantList");
        }
    }
}