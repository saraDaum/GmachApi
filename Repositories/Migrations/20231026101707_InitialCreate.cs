using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acounts_Borrowers",
                table: "Acount");

            migrationBuilder.DropForeignKey(
                name: "FK_AcountsForLoans_LoansDetails",
                table: "AcountsForLoans");

            migrationBuilder.DropForeignKey(
                name: "FK_Deposits_Depositors",
                table: "Deposits");

            migrationBuilder.DropForeignKey(
                name: "FK_Guarantors_LoansDetails",
                table: "Guarantors");

            migrationBuilder.DropTable(
                name: "Depositors");

            migrationBuilder.DropTable(
                name: "LoansGuarantors ");

            migrationBuilder.DropTable(
                name: "Borrowers");

            migrationBuilder.DropTable(
                name: "LoansDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Acounts_1",
                table: "Acount");

            migrationBuilder.DropIndex(
                name: "IX_Acounts",
                table: "Acount");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Guarantors",
                table: "Guarantors");

            migrationBuilder.RenameTable(
                name: "Acount",
                newName: "Acounts");

            migrationBuilder.RenameTable(
                name: "Guarantors",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "DepositorsID",
                table: "Deposits",
                newName: "DepositorsId");

            migrationBuilder.RenameColumn(
                name: "DepositID",
                table: "Deposits",
                newName: "DepositId");

            migrationBuilder.RenameIndex(
                name: "IX_Deposits_DepositorsID",
                table: "Deposits",
                newName: "IX_Deposits_DepositorsId");

            migrationBuilder.RenameColumn(
                name: "BorrowerID",
                table: "Acounts",
                newName: "BorrowerId");

            migrationBuilder.RenameColumn(
                name: "LoanID",
                table: "User",
                newName: "LoanId");

            migrationBuilder.RenameColumn(
                name: "guarantorName",
                table: "User",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "guarantorID",
                table: "User",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UserNumber",
                table: "User",
                newName: "UserIdentityNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Guarantors_LoanID",
                table: "User",
                newName: "IX_User_LoanId");

            migrationBuilder.AlterColumn<string>(
                name: "ConfirmAcountFile",
                table: "Acounts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "UserEmail",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(40)",
                oldFixedLength: true,
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "UserAddress",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<int>(
                name: "LoanId",
                table: "User",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "User",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "UserIdentityNumber",
                table: "User",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Copy",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Acounts",
                table: "Acounts",
                column: "AccontId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UserId");

            migrationBuilder.CreateTable(
                name: "LoanDetails",
                columns: table => new
                {
                    LoanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateToGetBack = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sum = table.Column<int>(type: "int", nullable: false),
                    BorrowerNumber = table.Column<int>(type: "int", nullable: false),
                    LoanFile = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanDetails", x => x.LoanId);
                });

            migrationBuilder.CreateTable(
                name: "BorrowerLoanDetails",
                columns: table => new
                {
                    BorrowersUserId = table.Column<int>(type: "int", nullable: false),
                    LoansLoanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowerLoanDetails", x => new { x.BorrowersUserId, x.LoansLoanId });
                    table.ForeignKey(
                        name: "FK_BorrowerLoanDetails_LoanDetails_LoansLoanId",
                        column: x => x.LoansLoanId,
                        principalTable: "LoanDetails",
                        principalColumn: "LoanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BorrowerLoanDetails_User_BorrowersUserId",
                        column: x => x.BorrowersUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acounts_BorrowerId",
                table: "Acounts",
                column: "BorrowerId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowerLoanDetails_LoansLoanId",
                table: "BorrowerLoanDetails",
                column: "LoansLoanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acounts_User_BorrowerId",
                table: "Acounts",
                column: "BorrowerId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AcountsForLoans_LoansDetails",
                table: "AcountsForLoans",
                column: "LoanID",
                principalTable: "LoanDetails",
                principalColumn: "LoanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deposits_User_DepositorsId",
                table: "Deposits",
                column: "DepositorsId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_LoanDetails_LoanId",
                table: "User",
                column: "LoanId",
                principalTable: "LoanDetails",
                principalColumn: "LoanId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acounts_User_BorrowerId",
                table: "Acounts");

            migrationBuilder.DropForeignKey(
                name: "FK_AcountsForLoans_LoansDetails",
                table: "AcountsForLoans");

            migrationBuilder.DropForeignKey(
                name: "FK_Deposits_User_DepositorsId",
                table: "Deposits");

            migrationBuilder.DropForeignKey(
                name: "FK_User_LoanDetails_LoanId",
                table: "User");

            migrationBuilder.DropTable(
                name: "BorrowerLoanDetails");

            migrationBuilder.DropTable(
                name: "LoanDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Acounts",
                table: "Acounts");

            migrationBuilder.DropIndex(
                name: "IX_Acounts_BorrowerId",
                table: "Acounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Copy",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "User");

            migrationBuilder.RenameTable(
                name: "Acounts",
                newName: "Acount");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Guarantors");

            migrationBuilder.RenameColumn(
                name: "DepositorsId",
                table: "Deposits",
                newName: "DepositorsID");

            migrationBuilder.RenameColumn(
                name: "DepositId",
                table: "Deposits",
                newName: "DepositID");

            migrationBuilder.RenameIndex(
                name: "IX_Deposits_DepositorsId",
                table: "Deposits",
                newName: "IX_Deposits_DepositorsID");

            migrationBuilder.RenameColumn(
                name: "BorrowerId",
                table: "Acount",
                newName: "BorrowerID");

            migrationBuilder.RenameColumn(
                name: "LoanId",
                table: "Guarantors",
                newName: "LoanID");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Guarantors",
                newName: "guarantorName");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Guarantors",
                newName: "guarantorID");

            migrationBuilder.RenameColumn(
                name: "UserIdentityNumber",
                table: "Guarantors",
                newName: "UserNumber");

            migrationBuilder.RenameIndex(
                name: "IX_User_LoanId",
                table: "Guarantors",
                newName: "IX_Guarantors_LoanID");

            migrationBuilder.AlterColumn<string>(
                name: "ConfirmAcountFile",
                table: "Acount",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserEmail",
                table: "Guarantors",
                type: "nchar(40)",
                fixedLength: true,
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserAddress",
                table: "Guarantors",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "LoanID",
                table: "Guarantors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "guarantorName",
                table: "Guarantors",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "guarantorID",
                table: "Guarantors",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "UserNumber",
                table: "Guarantors",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Acounts_1",
                table: "Acount",
                column: "AccontId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Guarantors",
                table: "Guarantors",
                column: "UserNumber");

            migrationBuilder.CreateTable(
                name: "Borrowers",
                columns: table => new
                {
                    UserNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CopyID = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    UserAddress = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    UserEmail = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPhone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrowers", x => x.UserNumber);
                });

            migrationBuilder.CreateTable(
                name: "Depositors",
                columns: table => new
                {
                    UserNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserAddress = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    userEmail = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPhone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depositors", x => x.UserNumber);
                });

            migrationBuilder.CreateTable(
                name: "LoansDetails",
                columns: table => new
                {
                    LoanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BorrowerNumber = table.Column<int>(type: "int", nullable: false),
                    DateToGetBack = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoanFile = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Sum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoansDetails", x => x.LoanID);
                });

            migrationBuilder.CreateTable(
                name: "LoansGuarantors ",
                columns: table => new
                {
                    LoanID = table.Column<int>(type: "int", nullable: false),
                    BorrowerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoansConectoin", x => new { x.LoanID, x.BorrowerID });
                    table.ForeignKey(
                        name: "FK_LoansGuarantors _Borrowers",
                        column: x => x.BorrowerID,
                        principalTable: "Borrowers",
                        principalColumn: "UserNumber");
                    table.ForeignKey(
                        name: "FK_LoansGuarantors _LoansDetails",
                        column: x => x.LoanID,
                        principalTable: "LoansDetails",
                        principalColumn: "LoanID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acounts",
                table: "Acount",
                columns: new[] { "BorrowerID", "AcountsNumber", "BankNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoansGuarantors _BorrowerID",
                table: "LoansGuarantors ",
                column: "BorrowerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Acounts_Borrowers",
                table: "Acount",
                column: "BorrowerID",
                principalTable: "Borrowers",
                principalColumn: "UserNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_AcountsForLoans_LoansDetails",
                table: "AcountsForLoans",
                column: "LoanID",
                principalTable: "LoansDetails",
                principalColumn: "LoanID");

            migrationBuilder.AddForeignKey(
                name: "FK_Deposits_Depositors",
                table: "Deposits",
                column: "DepositorsID",
                principalTable: "Depositors",
                principalColumn: "UserNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Guarantors_LoansDetails",
                table: "Guarantors",
                column: "LoanID",
                principalTable: "LoansDetails",
                principalColumn: "LoanID");
        }
    }
}
