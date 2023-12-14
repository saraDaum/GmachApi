using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class changeTypeOfLoanIdInGuarantor2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateToPull",
    table: "Deposits",
    type: "datetime",
    nullable: false,
    oldClrType: typeof(DateOnly),
    oldType: "date");
            //migrationBuilder.Sql("ALTER TABLE Guarantors ADD LoanId int NOT NULL");

            /*migrationBuilder.DropColumn(
             name: "LoanDetaiksLoanId",
              table: "Guarantors"
              );

            migrationBuilder.AddColumn<string>(
                name: "LoanId",
                table: "Guarantors",
                nullable: false);


            migrationBuilder.AlterColumn<int>(
                name: "LoanId",
                table: "Guarantors",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           /* migrationBuilder.AddColumn<string>(
              name: "LoanDetaiksLoanId",
              table: "Guarantors"
              );

            migrationBuilder.DropColumn(
                 name: "LoanId",
                table: "Guarantors"
              );

            migrationBuilder.AlterColumn<string>(
                name: "LoanId",
                table: "Guarantors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");*/
        }
    }
}
