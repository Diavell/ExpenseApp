using ExpenseApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenseApplication.Controllers
{
    public class ManagerController : Controller
    {
        ExpenseDataEntities7 db = new ExpenseDataEntities7();
        
        public ActionResult ManagerList()
        {
            return View(db.AddExpense.Where(x => x.expenseApproval == "Beklemede").ToList());
        }

        public ActionResult Edit(int id)
        {
            //return View(db.AddExpense.Where(x => x.userId == 1).ToList());
            var expense = db.AddExpense.Where(x => x.expenseId == id).FirstOrDefault();
            TempData["expenseId"] = id;
            return View(expense);
        }

        [HttpPost]
        public ActionResult Edit(AddExpense expense)
        {
            int id = (int)TempData["expenseId"];
            var update = db.AddExpense.Where(x => x.expenseId == id).FirstOrDefault();
            update.expenseApproval = "Reddedildi";
            update.approvalInfo = expense.approvalInfo;

            db.SaveChanges();

            return RedirectToAction("ManagerList");
        }
        
        public ActionResult Appvoral(int id)
        {
            var update = db.AddExpense.Where(x => x.expenseId == id).FirstOrDefault();
            update.expenseApproval = "Onaylandı";
            db.SaveChanges();
            return RedirectToAction("ManagerList");
        }


        //public ActionResult Approval(int id, string info)
        //{
        //    int ID = Convert.ToInt32(id);
        //    var expense = db.AddExpense.Where(x => x.expenseId == ID).FirstOrDefault();

        //    expense.expenseApproval = "Onaylandı";
        //    expense.approvalInfo = info;

        //    db.SaveChanges();
        //    return RedirectToAction("List");
        //}

        //public ActionResult DisApproval(AddExpense expense)
        //{
        //    //int ID = Convert.ToInt32(id);
        //    var kayit = db.AddExpense.Where(x => x.expenseId == expense.expenseId).FirstOrDefault();

        //    kayit.expenseApproval = "Reddedildi";
        //    kayit.approvalInfo = expense.expenseApproval;

        //    db.SaveChanges();
        //    return RedirectToAction("List");
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Update_Insert(AddExpense obj)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (obj.expenseId == 0)
        //        {
        //            //Create (Oluşturma)
        //            db.AddExpense.Add(obj);
        //        }
        //        else
        //        {
        //            //Update (Güncelleme)
        //            db.AddExpense.Update();
        //        }
        //        db.SaveChanges();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(obj);
        //}

        ////public AddExpense Approval(int id)
        //{
        //    using (var ctx = new ExpenseDataEntities7())
        //    {
        //        AddExpense Customer = new AddExpense();
        //        Customer = (from x in ctx.AddExpense
        //                    where x.expenseId == id
        //                    select x).FirstOrDefault();
        //        return Customer;
        //    }
        //}


        ////public ActionResult AppRoval(int id)
        ////{
        ////    Approval()
        ////}

        //public AddExpense Approval(AddExpense update)
        //{
        //    using (var ctx = new ExpenseDataEntities7())
        //    {
        //        var c = ctx.AddExpense.FirstOrDefault(i => i.expenseId == update.expenseId);
        //        if (c != null)
        //        {
        //            c.expenseApproval = "Onaylandı";
        //            ctx.SaveChanges();
        //        }
        //        return c;
        //    }
        //}
    }
}