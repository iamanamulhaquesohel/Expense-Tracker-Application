using Expense_Tracker_Application.Validation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Expense_Tracker_Application.Models
{
    //Code-First Approach//

    //ExpenseCategory Class or Table
    public class ExpenseCategory
    {
        public ExpenseCategory()
        {
            this.DailyExpenses = new List<DailyExpense>();
        }
        public int ExpenseCategoryId { get; set; }
        [Required, StringLength(60), Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        //Navigation
        public virtual ICollection<DailyExpense> DailyExpenses { get; set; }
    }

    //DailyExpense Class or Table
    public class DailyExpense 
    {
        public int DailyExpenseId { get; set; }
        [Required, Column(TypeName ="date"), FutureDatePickValidation(ErrorMessage ="Expense Date Can not be Future Date"), Display(Name = "Expense Date")]
        public DateTime ExpenseDate { get; set; }
        [Required, Column(TypeName="money"), Display(Name ="Amount(TK)")]
        public decimal Amount { get; set; }
        //Foreign Key Set or Relation between ExpenseCategory to Daily Expense
        [Required, ForeignKey("ExpenseCategory"), Display(Name = "Categories Name")]
        public int ExpenseCategoryId { get; set; }

        //Navigation
        public virtual ExpenseCategory ExpenseCategory { get; set; }
    }

    public class ExpenseTrackerDbContext : DbContext
    {   
        public ExpenseTrackerDbContext(DbContextOptions<ExpenseTrackerDbContext> options) : base(options) { }

        //Dbset Entity
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public DbSet<DailyExpense> DailyExpenses { get; set; }

        //Adding Expense Category on model Creating into the database
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<ExpenseCategory>().HasData(
                new ExpenseCategory { ExpenseCategoryId = 1, CategoryName = "House Rent" },
                new ExpenseCategory { ExpenseCategoryId = 2, CategoryName = "Water Bill" },
                new ExpenseCategory { ExpenseCategoryId = 3, CategoryName = "Electric Bill" },
                new ExpenseCategory { ExpenseCategoryId = 4, CategoryName = "Groceries" },
                new ExpenseCategory { ExpenseCategoryId = 5, CategoryName = "Uber" },
                new ExpenseCategory { ExpenseCategoryId = 6, CategoryName = "Medications" }
                );
            modelBuilder.Entity<DailyExpense>().HasData(
                new DailyExpense { DailyExpenseId =1, ExpenseDate = new DateTime(2021, 12, 08), ExpenseCategoryId = 1, Amount= 4000.00M },
                new DailyExpense { DailyExpenseId =2, ExpenseDate = new DateTime(2021, 12, 07), ExpenseCategoryId = 2, Amount= 5000.00M },
                new DailyExpense { DailyExpenseId =3, ExpenseDate = new DateTime(2021, 12, 06), ExpenseCategoryId = 3, Amount= 6000.00M },
                new DailyExpense { DailyExpenseId =4, ExpenseDate = new DateTime(2021, 12, 05), ExpenseCategoryId = 4, Amount= 7000.00M },
                new DailyExpense { DailyExpenseId =5, ExpenseDate = new DateTime(2021, 12, 04), ExpenseCategoryId = 5, Amount= 8000.00M },
                new DailyExpense { DailyExpenseId =6, ExpenseDate = new DateTime(2021, 12, 03), ExpenseCategoryId = 6, Amount= 3000.00M }
                );
        }
    }

   
}
