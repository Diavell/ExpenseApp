using ExpenseApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenseApplication.Controllers
{
    public class ListExpenseController : Controller
    {
        ExpenseDataEntities7 db = new ExpenseDataEntities7();
        public ActionResult List()
        {
            int ID = (int)TempData["Id"];
            ViewBag.Sum = db.AddExpense.Where(x => x.userId == ID && x.expenseApproval != "Ödendi").Sum(x => x.expensePrice);
            if (ID == 1)
            {
                return View(db.AddExpense.Where(x => x.userId == 1).ToList());
            }
            else if (ID == 2)
            {
                return View(db.AddExpense.Where(x => x.userId == 2).ToList());
            }
            else if (ID == 3)
            {
                return View(db.AddExpense.Where(x => x.userId == 3).ToList());
            }
            else if (ID == 4)
            {
                return View(db.AddExpense.Where(x => x.userId == 4).ToList());
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var expense = db.AddExpense.Where(x => x.expenseId == id).FirstOrDefault();
            TempData["expenseId"] = id;
            return View(expense);
        }

        [HttpPost]
        public ActionResult Edit(AddExpense expense)
        {
            int id = (int)TempData["expenseId"];
            var update = db.AddExpense.Where(x => x.expenseId == id).FirstOrDefault();
            update.approvalInfo = expense.approvalInfo;
            update.expenseName = expense.expenseName;
            update.expensePrice = expense.expensePrice;
            update.expenseCurrency = expense.expenseCurrency;
            update.expenseDate = expense.expenseDate;
            update.expenseAim = expense.expenseAim;

            db.SaveChanges();

            return RedirectToAction("Index","Home");
        }

        public ActionResult Delete(string id)
        {
            var ID = Convert.ToInt32(id);
            AddExpense delete = db.AddExpense.Where(x => x.expenseId == ID).FirstOrDefault();
            db.AddExpense.Remove(delete);
            db.SaveChanges();

            return RedirectToAction("Index","Home");
        }
    }
}