using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Expense_Tracker_Application.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpenseCategories",
                columns: table => new
                {
                    ExpenseCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseCategories", x => x.ExpenseCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "DailyExpenses",
                columns: table => new
                {
                    DailyExpenseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseDate = table.Column<DateTime>(type: "date", nullable: false),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    ExpenseCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyExpenses", x => x.DailyExpenseId);
                    table.ForeignKey(
                        name: "FK_DailyExpenses_ExpenseCategories_ExpenseCategoryId",
                        column: x => x.ExpenseCategoryId,
                        principalTable: "ExpenseCategories",
                        principalColumn: "ExpenseCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ExpenseCategories",
                columns: new[] { "ExpenseCategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "House Rent" },
                    { 2, "Water Bill" },
                    { 3, "Electric Bill" },
                    { 4, "Groceries" },
                    { 5, "Uber" },
                    { 6, "Medications" }
                });

            migrationBuilder.InsertData(
                table: "DailyExpenses",
                columns: new[] { "DailyExpenseId", "Amount", "ExpenseCategoryId", "ExpenseDate" },
                values: new object[,]
                {
                    { 1, 4000.00m, 1, new DateTime(2021, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 5000.00m, 2, new DateTime(2021, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 6000.00m, 3, new DateTime(2021, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 7000.00m, 4, new DateTime(2021, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 8000.00m, 5, new DateTime(2021, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 3000.00m, 6, new DateTime(2021, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyExpenses_ExpenseCategoryId",
                table: "DailyExpenses",
                column: "ExpenseCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyExpenses");

            migrationBuilder.DropTable(
                name: "ExpenseCategories");
        }
    }
}
