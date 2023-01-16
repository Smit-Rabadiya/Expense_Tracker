using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Migrations
{
    /// <inheritdoc />
    public partial class AddBothTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    CategoryLimit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Expense_Limit",
                columns: table => new
                {
                    LimitID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseLimit = table.Column<int>(name: "Expense_Limit", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expense_Limit", x => x.LimitID);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    ExpenseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.ExpenseId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Expense_Limit");

            migrationBuilder.DropTable(
                name: "Expenses");
        }
    }
}
