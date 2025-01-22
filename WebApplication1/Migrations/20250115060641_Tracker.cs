using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Tracker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    currencyCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    currencyId = table.Column<int>(type: "int", nullable: false),
                    exchangeRate = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.currencyCode);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "Budgets",
                columns: table => new
                {
                    budgetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    totalBudget = table.Column<int>(type: "int", nullable: false),
                    Threshold = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgets", x => x.budgetId);
                    table.ForeignKey(
                        name: "FK_Budgets_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    categoriesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    categoriesName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.categoriesId);
                    table.ForeignKey(
                        name: "FK_Categories_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    transactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    categoriesId = table.Column<int>(type: "int", nullable: false),
                    txn_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    amount = table.Column<int>(type: "int", nullable: false),
                    txnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    recurring = table.Column<bool>(type: "bit", nullable: true),
                    payment_Method = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    currencyCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    userId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.transactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_Categories_categoriesId",
                        column: x => x.categoriesId,
                        principalTable: "Categories",
                        principalColumn: "categoriesId");
                    table.ForeignKey(
                        name: "FK_Transactions_Currencies_currencyCode",
                        column: x => x.currencyCode,
                        principalTable: "Currencies",
                        principalColumn: "currencyCode");
                    table.ForeignKey(
                        name: "FK_Transactions_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "userId");
                    table.ForeignKey(
                        name: "FK_Transactions_Users_userId1",
                        column: x => x.userId1,
                        principalTable: "Users",
                        principalColumn: "userId");
                });

            migrationBuilder.CreateTable(
                name: "RecurringTxns",
                columns: table => new
                {
                    recurringTxnId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    transactionId = table.Column<int>(type: "int", nullable: false),
                    frequencyStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    recurrableDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecurringTxns", x => x.recurringTxnId);
                    table.ForeignKey(
                        name: "FK_RecurringTxns_Transactions_transactionId",
                        column: x => x.transactionId,
                        principalTable: "Transactions",
                        principalColumn: "transactionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecurringTxns_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_userId",
                table: "Budgets",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_userId",
                table: "Categories",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringTxns_transactionId",
                table: "RecurringTxns",
                column: "transactionId");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringTxns_userId",
                table: "RecurringTxns",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_categoriesId",
                table: "Transactions",
                column: "categoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_currencyCode",
                table: "Transactions",
                column: "currencyCode");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_userId",
                table: "Transactions",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_userId1",
                table: "Transactions",
                column: "userId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Budgets");

            migrationBuilder.DropTable(
                name: "RecurringTxns");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
