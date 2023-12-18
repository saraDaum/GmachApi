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
            //migrationBuilder.CreateTable(
            //    name: "Accounts",
            //    columns: table => new
            //    {
            //        AccontId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserId = table.Column<int>(type: "int", nullable: false),
            //        AccountsNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        BankNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Branch = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        OwnerIdNumber = table.Column<string>(type: "nvarchar(9)", nullable: false),
            //        ConfirmAcountFile = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Accounts", x => x.AccontId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Cards",
            //    columns: table => new
            //    {
            //        CardId = table.Column<int>(type: "int", nullable: false)
            //    .Annotation("SqlServer:Identity", "1,1"),
            //        UserId = table.Column<int>(type: "int", nullable: false),
            //        CreditCardNumber = table.Column<string>(type: "nvarchar(16)", nullable: false),
            //        OwnersName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        CVV = table.Column<string>(type: "nvarchar(3)", nullable: false),
            //        Validity = table.Column<string>(type: "nvarchar(7)", nullable: false),
            //    },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Cards", x => x.CardId);
            //     });
       


            //migrationBuilder.CreateTable(
            //    name: "Deposits",
            //    columns: table => new
            //    {
            //        DepositId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserId = table.Column<int>(type: "int", nullable: false),
            //        Sum = table.Column<int>(type: "int", nullable: false),
            //        DateToPull = table.Column<DateTime>(type: "datetime2", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Deposits", x => x.DepositId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "LoanDetails",
            //    columns: table => new
            //    {
            //        LoanId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        LoanerId = table.Column<int>(type: "int", nullable: false),
            //        DateToGetBack = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        Sum = table.Column<int>(type: "int", nullable: false),
            //        UserId = table.Column<int>(type: "int", nullable: false),
            //        LoanFile = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_LoanDetails", x => x.LoanId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Users",
            //    columns: table => new
            //    {
            //        UserId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserIdentityNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        UserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            //        UserPassword = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            //        UserEmail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            //        UserAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            //        UserPhone = table.Column<int>(type: "int", nullable: false),
            //        //RollId = table.Column<int>(type: "int", nullable: false)
                    
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Users", x => x.UserId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Guarantors",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        AccountAccontId = table.Column<int>(type: "int", nullable: false),
            //        LoanDetailsLoanId = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Guarantors", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Guarantors_Accounts_AccountAccontId",
            //            column: x => x.AccountAccontId,
            //            principalTable: "Accounts",
            //            principalColumn: "AccontId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Guarantors_LoanDetails_LoanDetailsLoanId",
            //            column: x => x.LoanDetailsLoanId,
            //            principalTable: "LoanDetails",
            //            principalColumn: "LoanId");
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Guarantors_AccountAccontId",
            //    table: "Guarantors",
            //    column: "AccountAccontId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Guarantors_LoanDetailsLoanId",
            //    table: "Guarantors",
            //    column: "LoanDetailsLoanId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Users_UserIdentityNumber",
            //    table: "Users",
            //    column: "UserIdentityNumber",
            //    unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Deposits");

            //migrationBuilder.DropTable(
            //    name: "Guarantors");

            //migrationBuilder.DropTable(
            //    name: "Users");

            //migrationBuilder.DropTable(
            //    name: "Accounts");

            //migrationBuilder.DropTable(
            //    name: "LoanDetails");
        }
    }
}