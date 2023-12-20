using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class RenameAccountId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
         /*   migrationBuilder.RenameColumn(
                name: "Id",
                table: "Accounts",
                newName: "AccountId");*/

            /*migrationBuilder.RenameColumn(
             name: "AccountId",
             table: "Card",
             newName: "CardId");*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Accounts",
                newName: "Id");*/

            /*migrationBuilder.RenameColumn(
             name: "AccountId",
             table: "Card",
             newName: "CardId");*/
        }
    }
}