using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class CreateUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_User_LoanId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Acounts",
                table: "Acounts");

            migrationBuilder.DropIndex(
                name: "IX_Acounts_BorrowerId",
                table: "Acounts");

            migrationBuilder.DropColumn(
                name: "Copy",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LoanId",
                table: "User");

            migrationBuilder.RenameTable(
                name: "Acounts",
                newName: "Acount");

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

            migrationBuilder.AlterColumn<string>(
                name: "ConfirmAcountFile",
                table: "Acount",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "LoanDetailsLoanId",
                table: "Acount",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Acounts_1",
                table: "Acount",
                column: "AccontId");

            migrationBuilder.CreateTable(
                name: "Borrowers",
                columns: table => new
                {
                    UserNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CopyID = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    UserAddress = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    UserPhone = table.Column<int>(type: "int", nullable: false),
                    UserEmail = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoanDetailsLoanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrowers", x => x.UserNumber);
                    table.ForeignKey(
                        name: "FK_Borrowers_LoanDetails_LoanDetailsLoanId",
                        column: x => x.LoanDetailsLoanId,
                        principalTable: "LoanDetails",
                        principalColumn: "LoanId");
                });

            migrationBuilder.CreateTable(
                name: "Depositors",
                columns: table => new
                {
                    UserNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    UserAddress = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    UserPhone = table.Column<int>(type: "int", nullable: false),
                    userEmail = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    DateToGetBack = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sum = table.Column<int>(type: "int", nullable: false),
                    BorrowerNumber = table.Column<int>(type: "int", nullable: false),
                    LoanFile = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoansDetails", x => x.LoanID);
                });

            migrationBuilder.CreateTable(
                name: "Guarantors",
                columns: table => new
                {
                    UserNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanID = table.Column<int>(type: "int", nullable: false),
                    guarantorName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    guarantorID = table.Column<int>(type: "int", nullable: false),
                    UserAddress = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    UserPhone = table.Column<int>(type: "int", nullable: false),
                    UserEmail = table.Column<string>(type: "nchar(40)", fixedLength: true, maxLength: 40, nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoanDetailsLoanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guarantors", x => x.UserNumber);
                    table.ForeignKey(
                        name: "FK_Guarantors_LoanDetails_LoanDetailsLoanId",
                        column: x => x.LoanDetailsLoanId,
                        principalTable: "LoanDetails",
                        principalColumn: "LoanId");
                    table.ForeignKey(
                        name: "FK_Guarantors_LoansDetails",
                        column: x => x.LoanID,
                        principalTable: "LoansDetails",
                        principalColumn: "LoanID");
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
                name: "IX_Acount_LoanDetailsLoanId",
                table: "Acount",
                column: "LoanDetailsLoanId");

            migrationBuilder.CreateIndex(
                name: "IX_Acounts",
                table: "Acount",
                columns: new[] { "BorrowerID", "AcountsNumber", "BankNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Borrowers_LoanDetailsLoanId",
                table: "Borrowers",
                column: "LoanDetailsLoanId");

            migrationBuilder.CreateIndex(
                name: "IX_Guarantors_LoanDetailsLoanId",
                table: "Guarantors",
                column: "LoanDetailsLoanId");

            migrationBuilder.CreateIndex(
                name: "IX_Guarantors_LoanID",
                table: "Guarantors",
                column: "LoanID");

            migrationBuilder.CreateIndex(
                name: "IX_LoansGuarantors _BorrowerID",
                table: "LoansGuarantors ",
                column: "BorrowerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Acount_LoanDetails_LoanDetailsLoanId",
                table: "Acount",
                column: "LoanDetailsLoanId",
                principalTable: "LoanDetails",
                principalColumn: "LoanId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acount_LoanDetails_LoanDetailsLoanId",
                table: "Acount");

            migrationBuilder.DropForeignKey(
                name: "FK_Acounts_Borrowers",
                table: "Acount");

            migrationBuilder.DropForeignKey(
                name: "FK_AcountsForLoans_LoansDetails",
                table: "AcountsForLoans");

            migrationBuilder.DropForeignKey(
                name: "FK_Deposits_Depositors",
                table: "Deposits");

            migrationBuilder.DropTable(
                name: "Depositors");

            migrationBuilder.DropTable(
                name: "Guarantors");

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
                name: "IX_Acount_LoanDetailsLoanId",
                table: "Acount");

            migrationBuilder.DropIndex(
                name: "IX_Acounts",
                table: "Acount");

            migrationBuilder.DropColumn(
                name: "LoanDetailsLoanId",
                table: "Acount");

            migrationBuilder.RenameTable(
                name: "Acount",
                newName: "Acounts");

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

            migrationBuilder.AddColumn<int>(
                name: "LoanId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConfirmAcountFile",
                table: "Acounts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Acounts",
                table: "Acounts",
                column: "AccontId");

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
                name: "IX_User_LoanId",
                table: "User",
                column: "LoanId");

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
    }
}
