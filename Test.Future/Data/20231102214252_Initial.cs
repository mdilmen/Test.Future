using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Test.Future.Data
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Futures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HS_ExpenseId = table.Column<int>(type: "int", nullable: true),
                    CardName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PolicyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PolicyBeginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PolicyEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InstallmentCount = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentMethodType = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Futures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Futures_Expenses_HS_ExpenseId",
                        column: x => x.HS_ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Name", "Order" },
                values: new object[,]
                {
                    { 1, "Sigorta", 1 },
                    { 2, "Kasko", 2 },
                    { 3, "Kira", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Futures_HS_ExpenseId",
                table: "Futures",
                column: "HS_ExpenseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Futures");

            migrationBuilder.DropTable(
                name: "Expenses");
        }
    }
}
