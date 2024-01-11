using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations;

/// <inheritdoc />
public partial class AddSafe : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<bool>(
            name: "Safe",
            table: "LoanDetails",
            type: "bit",
            nullable: false,
            defaultValue: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "Safe",
            table: "LoanDetails");
    }
}
