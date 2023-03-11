using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicTacToe.Persistence.Migrations
{
    public partial class AddedQueue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "playerQueue",
                table: "GameTables",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "playerQueue",
                table: "GameTables");
        }
    }
}
