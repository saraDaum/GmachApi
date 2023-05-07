using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class AddUserClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "Acount",
                columns: table => new
                {
                    AccontId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BorrowerID = table.Column<int>(type: "int", nullable: false),
                    AcountsNumber = table.Column<int>(type: "int", nullable: false),
                    BankNumber = table.Column<int>(type: "int", nullable: false),
                    Branch = table.Column<int>(type: "int", nullable: false),
                    ConfirmAcountFile = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acounts_1", x => x.AccontId);
                    table.ForeignKey(
                        name: "FK_Acounts_Borrowers",
                        column: x => x.BorrowerID,
                        principalTable: "Borrowers",
                        principalColumn: "UserNumber");
                });

            migrationBuilder.CreateTable(
                name: "Deposits",
                columns: table => new
                {
                    DepositID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepositorsID = table.Column<int>(type: "int", nullable: false),
                    Sum = table.Column<int>(type: "int", nullable: false),
                    DateToPull = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposits", x => x.DepositID);
                    table.ForeignKey(
                        name: "FK_Deposits_Depositors",
                        column: x => x.DepositorsID,
                        principalTable: "Depositors",
                        principalColumn: "UserNumber");
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
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guarantors", x => x.UserNumber);
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

            migrationBuilder.CreateTable(
                name: "AcountsForLoans",
                columns: table => new
                {
                    LoanID = table.Column<int>(type: "int", nullable: false),
                    AcountsNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcountsForLoans", x => new { x.LoanID, x.AcountsNumber });
                    table.ForeignKey(
                        name: "FK_AcountsForLoans_Acounts",
                        column: x => x.AcountsNumber,
                        principalTable: "Acount",
                        principalColumn: "AccontId");
                    table.ForeignKey(
                        name: "FK_AcountsForLoans_LoansDetails",
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
                name: "IX_AcountsForLoans_AcountsNumber",
                table: "AcountsForLoans",
                column: "AcountsNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Deposits_DepositorsID",
                table: "Deposits",
                column: "DepositorsID");

            migrationBuilder.CreateIndex(
                name: "IX_Guarantors_LoanID",
                table: "Guarantors",
                column: "LoanID");

            migrationBuilder.CreateIndex(
                name: "IX_LoansGuarantors _BorrowerID",
                table: "LoansGuarantors ",
                column: "BorrowerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcountsForLoans");

            migrationBuilder.DropTable(
                name: "Deposits");

            migrationBuilder.DropTable(
                name: "Guarantors");

            migrationBuilder.DropTable(
                name: "LoansGuarantors ");

            migrationBuilder.DropTable(
                name: "Acount");

            migrationBuilder.DropTable(
                name: "Depositors");

            migrationBuilder.DropTable(
                name: "LoansDetails");

            migrationBuilder.DropTable(
                name: "Borrowers");
        }
    }
}
