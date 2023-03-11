using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TicTacToe.Persistence.Migrations
{
    public partial class UpdateTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameTables_Users_oneXId",
                table: "GameTables");

            migrationBuilder.DropForeignKey(
                name: "FK_GameTables_Users_twoOId",
                table: "GameTables");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_GameTables_oneXId",
                table: "GameTables");

            migrationBuilder.DropIndex(
                name: "IX_GameTables_twoOId",
                table: "GameTables");

            migrationBuilder.DropColumn(
                name: "oneXId",
                table: "GameTables");

            migrationBuilder.DropColumn(
                name: "twoOId",
                table: "GameTables");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "oneXId",
                table: "GameTables",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "twoOId",
                table: "GameTables",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameTables_oneXId",
                table: "GameTables",
                column: "oneXId");

            migrationBuilder.CreateIndex(
                name: "IX_GameTables_twoOId",
                table: "GameTables",
                column: "twoOId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Id",
                table: "Users",
                column: "Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GameTables_Users_oneXId",
                table: "GameTables",
                column: "oneXId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GameTables_Users_twoOId",
                table: "GameTables",
                column: "twoOId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
