using Expense_Tracker_Application.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expense_Tracker_Application.Controllers
{
    public class ExpenseCategoriesController : Controller
    {
        //Database Context or dependency Injection
        private readonly ExpenseTrackerDbContext db;
        public ExpenseCategoriesController(ExpenseTrackerDbContext db) { this.db = db; }
        
        //Index Action
        public IActionResult Index()
        {
            return View(db.ExpenseCategories.ToList());
        }

        //Create Action
        public IActionResult Create()
        {
            return View();
        }
        //HTTP POST Create Action
        [HttpPost]
        public IActionResult Create(ExpenseCategory category)
        {
            if (ModelState.IsValid)
            {
                if (db.ExpenseCategories.Any(x=> x.CategoryName.ToLower() == category.CategoryName.ToLower()))
                {
                    // ModelState.AddModelError("", "Expense Category name already exits");
                    return PartialView("_MessegeCreateDuplicatePartial", false);
                }
                db.ExpenseCategories.Add(category);
                db.SaveChanges();
                return PartialView("_MessegeCreatePartial", true);
            }
            return PartialView("_MessegeCreatePartial", false);
        }

        //Update Action
        public IActionResult Update(int id)
        {
            return View(db.ExpenseCategories.FirstOrDefault(x=> x.ExpenseCategoryId == id));
        }
        //HTTP POST Update Action
        [HttpPost]
        public IActionResult Update(ExpenseCategory category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return PartialView("_MessegeUpdatePartial", true);
            }
            return PartialView("_MessegeUpdatePartial", false);
        }

        //Delete Action
        public IActionResult Delete(int id)
        {
            return View(db.ExpenseCategories.FirstOrDefault(x=>x.ExpenseCategoryId == id));
        }
        //HTTP POST Delete Action
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteDone(int id)
        {
            var category = new ExpenseCategory { ExpenseCategoryId = id };
            if (!db.DailyExpenses.Any(x=> x.ExpenseCategoryId == id))
            {
                db.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                db.SaveChanges();
                return PartialView("_MessegeDeletePartial", true);
            }
            return PartialView("_MessegeDeletePartial", false);
        }
        
    }
}
