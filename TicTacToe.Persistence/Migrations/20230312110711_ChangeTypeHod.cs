using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicTacToe.Persistence.Migrations
{
    public partial class ChangeTypeHod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hod",
                table: "GameTables");

            migrationBuilder.AddColumn<bool>(
                name: "PlayerHod",
                table: "GameTables",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlayerHod",
                table: "GameTables");

            migrationBuilder.AddColumn<int>(
                name: "Hod",
                table: "GameTables",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
