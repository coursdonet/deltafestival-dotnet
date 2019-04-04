using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class changecheckpoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Checkpoints");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDisabled",
                table: "Checkpoints",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastDisabled",
                table: "Checkpoints");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Checkpoints",
                nullable: false,
                defaultValue: false);
        }
    }
}
