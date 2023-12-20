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
            migrationBuilder.RenameColumn(
                name: "OwnerFullName",
                table: "Account",
                newName: "ConfirmAccountFile");

            migrationBuilder.AddColumn<string>(
                name: "AccountOwnerName",
                table: "Account",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountOwnerName",
                table: "Account");

            migrationBuilder.RenameColumn(
                name: "ConfirmAccountFile",
                table: "Account",
                newName: "OwnerFullName");
        }
    }
}
