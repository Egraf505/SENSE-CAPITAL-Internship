using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicTacToe.Persistence.Migrations
{
    public partial class AddedMatrix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "p0",
                table: "GameTables");

            migrationBuilder.DropColumn(
                name: "p1",
                table: "GameTables");

            migrationBuilder.DropColumn(
                name: "p2",
                table: "GameTables");

            migrationBuilder.DropColumn(
                name: "p3",
                table: "GameTables");

            migrationBuilder.DropColumn(
                name: "p4",
                table: "GameTables");

            migrationBuilder.DropColumn(
                name: "p5",
                table: "GameTables");

            migrationBuilder.DropColumn(
                name: "p6",
                table: "GameTables");

            migrationBuilder.DropColumn(
                name: "p7",
                table: "GameTables");

            migrationBuilder.DropColumn(
                name: "p8",
                table: "GameTables");

            migrationBuilder.AddColumn<int?[]>(
                name: "playArea",
                table: "GameTables",
                type: "integer[]",
                nullable: false,
                defaultValue: new int?[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "playArea",
                table: "GameTables");

            migrationBuilder.AddColumn<bool>(
                name: "p0",
                table: "GameTables",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "p1",
                table: "GameTables",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "p2",
                table: "GameTables",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "p3",
                table: "GameTables",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "p4",
                table: "GameTables",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "p5",
                table: "GameTables",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "p6",
                table: "GameTables",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "p7",
                table: "GameTables",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "p8",
                table: "GameTables",
                type: "boolean",
                nullable: true);
        }
    }
}
