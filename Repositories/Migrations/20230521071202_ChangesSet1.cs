using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class ChangesSet1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserIdentityNumber = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    UserAddress = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    UserPhone = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
