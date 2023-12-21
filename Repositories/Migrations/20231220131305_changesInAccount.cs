using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class changesInAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.RenameColumn(
                name: "AccontId",
                table: "Account",
                newName: "AccountId");*/

            migrationBuilder.RenameColumn(
                name: "ConfirmAcountFile",
                table: "Account",
                newName: "ConfirmAccountfile");

            /*migrationBuilder.RenameColumn(
               name: "AccountsNumber",
               table: "Account",
               newName: "AccountNumber");

            migrationBuilder.AddColumn<string>(
                name: "AccountOwnerName",
                table: "Account",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
               name: "BranchNumber",
               table: "Account",
               type: "nvarchar(255)",
               maxLength: 255,
               nullable: false,
               defaultValue: "");

            migrationBuilder.RenameColumn(
               name: "AccountsNumber",
               table: "Account",
               newName: "AccountNumber");*/


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            /*migrationBuilder.RenameColumn(
               name: "AccountId",
               table: "Account",
               newName: "AccontId");*/


            migrationBuilder.RenameColumn(
                name: "ConfirmAccountfile",
                table: "Account",
                newName: "ConfirmAcountFile");

            /*migrationBuilder.DropColumn(
                name: "AccountOwnerName",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "BranchNumber",
                table: "Account");

            migrationBuilder.RenameColumn(
                name: "AccountNumber",
                table: "Account",
                newName: "AccountsNumber");
            /*migrationBuilder.DropColumn(
                name: "AccountOwnerName",
                table: "Account");

            migrationBuilder.RenameColumn(
                name: "ConfirmAccountFile",
                table: "Account",
                newName: "OwnerFullName");*/
        }
    }
}
