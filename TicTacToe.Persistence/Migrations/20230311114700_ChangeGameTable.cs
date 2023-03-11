using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicTacToe.Persistence.Migrations
{
    public partial class ChangeGameTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "playerQueue",
                table: "GameTables");

            migrationBuilder.AddColumn<int>(
                name: "Hod",
                table: "GameTables",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hod",
                table: "GameTables");

            migrationBuilder.AddColumn<string>(
                name: "playerQueue",
                table: "GameTables",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
