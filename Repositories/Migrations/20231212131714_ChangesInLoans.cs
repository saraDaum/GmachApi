using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class ChangesInLoans : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Guarantors_Accounts_AccountAccontId",
            //    table: "Guarantors");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Guarantors_LoanDetails_LoanDetailsLoanId",
            //    table: "Guarantors");

            //migrationBuilder.DropIndex(
            //    name: "IX_Guarantors_AccountAccontId",
            //    table: "Guarantors");

            //migrationBuilder.DropIndex(
            //    name: "IX_Guarantors_LoanDetailsLoanId",
            //    table: "Guarantors");

            //migrationBuilder.DropColumn(
            //    name: "LoanerId",
            //    table: "LoanDetails");

            //migrationBuilder.DropColumn(
            //    name: "AccountAccontId",
            //    table: "Guarantors");

            //migrationBuilder.DropColumn(
            //    name: "LoanDetailsLoanId",
            //    table: "Guarantors");

            //migrationBuilder.DropColumn(
            //    name: "AccountsNumber",
            //    table: "Accounts");

            //migrationBuilder.DropColumn(
            //    name: "BankNumber",
            //    table: "Accounts");

            //migrationBuilder.DropColumn(
            //    name: "Branch",
            //    table: "Accounts");

            //migrationBuilder.DropColumn(
            //    name: "ConfirmAcountFile",
            //    table: "Accounts");

            //migrationBuilder.RenameColumn(
            //    name: "OwnerIdNumber",
            //    table: "Accounts",
            //    newName: "OwnersName");

            //migrationBuilder.AddColumn<string>(
            //    name: "Check",
            //    table: "Guarantors",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<string>(
            //    name: "LoanId",
            //    table: "Guarantors",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<string>(
            //    name: "CVV",
            //    table: "Accounts",
            //    type: "nvarchar(3)",
            //    maxLength: 3,
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<string>(
            //    name: "CreditCardNumber",
            //    table: "Accounts",
            //    type: "nvarchar(16)",
            //    maxLength: 16,
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<DateTime>(
            //    name: "Validity",
            //    table: "Accounts",
            //    type: "datetime2",
            //    nullable: false,
            //    defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            //migrationBuilder.CreateTable(
            //    name: "UsersUnderWarning",
            //    columns: table => new
            //    {
            //        UserId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        //    migrationBuilder.DropTable(
        //        name: "UsersUnderWarning");

        //    migrationBuilder.DropColumn(
        //        name: "Check",
        //        table: "Guarantors");

        //    migrationBuilder.DropColumn(
        //        name: "LoanId",
        //        table: "Guarantors");

        //    migrationBuilder.DropColumn(
        //        name: "CVV",
        //        table: "Accounts");

        //    migrationBuilder.DropColumn(
        //        name: "CreditCardNumber",
        //        table: "Accounts");

        //    migrationBuilder.DropColumn(
        //        name: "Validity",
        //        table: "Accounts");

        //    migrationBuilder.RenameColumn(
        //        name: "OwnersName",
        //        table: "Accounts",
        //        newName: "OwnerIdNumber");

        //    migrationBuilder.AddColumn<int>(
        //        name: "LoanerId",
        //        table: "LoanDetails",
        //        type: "int",
        //        nullable: false,
        //        defaultValue: 0);

        //    migrationBuilder.AddColumn<int>(
        //        name: "AccountAccontId",
        //        table: "Guarantors",
        //        type: "int",
        //        nullable: false,
        //        defaultValue: 0);

        //    migrationBuilder.AddColumn<int>(
        //        name: "LoanDetailsLoanId",
        //        table: "Guarantors",
        //        type: "int",
        //        nullable: true);

        //    migrationBuilder.AddColumn<string>(
        //        name: "AccountsNumber",
        //        table: "Accounts",
        //        type: "nvarchar(max)",
        //        nullable: false,
        //        defaultValue: "");

        //    migrationBuilder.AddColumn<string>(
        //        name: "BankNumber",
        //        table: "Accounts",
        //        type: "nvarchar(max)",
        //        nullable: false,
        //        defaultValue: "");

        //    migrationBuilder.AddColumn<string>(
        //        name: "Branch",
        //        table: "Accounts",
        //        type: "nvarchar(max)",
        //        nullable: false,
        //        defaultValue: "");

        //    migrationBuilder.AddColumn<string>(
        //        name: "ConfirmAcountFile",
        //        table: "Accounts",
        //        type: "nvarchar(255)",
        //        maxLength: 255,
        //        nullable: false,
        //        defaultValue: "");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Guarantors_AccountAccontId",
        //        table: "Guarantors",
        //        column: "AccountAccontId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Guarantors_LoanDetailsLoanId",
        //        table: "Guarantors",
        //        column: "LoanDetailsLoanId");

        //    migrationBuilder.AddForeignKey(
        //        name: "FK_Guarantors_Accounts_AccountAccontId",
        //        table: "Guarantors",
        //        column: "AccountAccontId",
        //        principalTable: "Accounts",
        //        principalColumn: "AccontId",
        //        onDelete: ReferentialAction.Cascade);

        //    migrationBuilder.AddForeignKey(
        //        name: "FK_Guarantors_LoanDetails_LoanDetailsLoanId",
        //        table: "Guarantors",
        //        column: "LoanDetailsLoanId",
        //        principalTable: "LoanDetails",
        //        principalColumn: "LoanId");
        }
    }
}
