using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class AddBankAccountTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Account",
            //    columns: table => new
            //    {
            //        AccountId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserId = table.Column<int>(type: "int", nullable: false),
            //        OwnerFullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            //        AccountNunber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        BankNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        BranchNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Account", x => x.AccountId);
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Account");
        }
    }
}
