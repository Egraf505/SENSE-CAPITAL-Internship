using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TicTacToe.Persistence.Migrations
{
    public partial class InitCreating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    oneXId = table.Column<int>(type: "integer", nullable: true),
                    twoOId = table.Column<int>(type: "integer", nullable: true),
                    p0 = table.Column<bool>(type: "boolean", nullable: true),
                    p1 = table.Column<bool>(type: "boolean", nullable: true),
                    p2 = table.Column<bool>(type: "boolean", nullable: true),
                    p3 = table.Column<bool>(type: "boolean", nullable: true),
                    p4 = table.Column<bool>(type: "boolean", nullable: true),
                    p5 = table.Column<bool>(type: "boolean", nullable: true),
                    p6 = table.Column<bool>(type: "boolean", nullable: true),
                    p7 = table.Column<bool>(type: "boolean", nullable: true),
                    p8 = table.Column<bool>(type: "boolean", nullable: true),
                    finished = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameTables_Users_oneXId",
                        column: x => x.oneXId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GameTables_Users_twoOId",
                        column: x => x.twoOId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameTables_Id",
                table: "GameTables",
                column: "Id",
                unique: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameTables");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
