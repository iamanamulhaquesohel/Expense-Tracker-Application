using Expense_Tracker_Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expense_Tracker_Application.Controllers
{
    public class DailyExpensesController : Controller
    {
        //Database Context or dependency Injection
        private readonly ExpenseTrackerDbContext db;
        public DailyExpensesController(ExpenseTrackerDbContext db) { this.db = db; }

        //Index Action
        public IActionResult Index(DateTime? from, DateTime? to)
        {
            //search Value check and show query
            if (from.HasValue && to.HasValue)
            {
                var searchData = db.DailyExpenses
                    .Include(x => x.ExpenseCategory)
                    .Where(x => x.ExpenseDate.Date >= from.Value.Date && x.ExpenseDate.Date <= to.Value.Date)
                    .ToList();
                return View(searchData);
            }
            else
            {
                var searchData = db.DailyExpenses.Include(x => x.ExpenseCategory).ToList();
                return View(searchData);
            }
        }

        //Create Action
        public IActionResult Create()
        {
            ViewBag.Categories = db.ExpenseCategories.ToList();
            return View();
        }
        //HTTP POST Create Action
        [HttpPost]
        public IActionResult Create(DailyExpense expense)
        {
            if (ModelState.IsValid)
            {
                db.DailyExpenses.Add(expense);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categories = db.ExpenseCategories.ToList();
            return View(expense);
        }

        //Update Action
        public IActionResult Update(int id)
        {
            ViewBag.Categories = db.ExpenseCategories.ToList();
            return View(db.DailyExpenses.FirstOrDefault(x => x.DailyExpenseId == id));
        }
        //HTTP POST Update Action
        [HttpPost]
        public IActionResult Update(DailyExpense expense)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expense).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categories = db.ExpenseCategories.ToList();
            return View(expense);
        }

        //Delete Action
        public IActionResult Delete(int id)
        {
            return View(db.DailyExpenses.Include(x => x.ExpenseCategory).FirstOrDefault(x => x.DailyExpenseId == id));
        }
        //HTTP POST Delete Action
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteDone(int id)
        {
            var expense = new DailyExpense { DailyExpenseId = id };
            db.Entry(expense).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}
