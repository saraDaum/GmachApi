using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate_ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           /* migrationBuilder.DropTable(
                name: "Accounts");
           */
            //migrationBuilder.CreateTable(
            //    name: "Card",
            //    columns: table => new
            //    {
            //        CardId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserId = table.Column<int>(type: "int", nullable: false),
            //        CreditCardNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
            //        OwnersName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        CVV = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
            //        Validity = table.Column<string>(type: "datetime2", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Card", x => x.CardId);
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        { 
            //migrationBuilder.DropTable(
            //    name: "Card");
/*
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccontId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CVV = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    CreditCardNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    OwnersName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Validity = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccontId);
                });
            */
        }
    }
}
