using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class Checkpointsupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuperUser_UserRole_UserRoleId",
                table: "SuperUser");

            migrationBuilder.AlterColumn<int>(
                name: "UserRoleId",
                table: "SuperUser",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "XAxis",
                table: "Checkpoint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YAxis",
                table: "Checkpoint",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SuperUser_UserRole_UserRoleId",
                table: "SuperUser",
                column: "UserRoleId",
                principalTable: "UserRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuperUser_UserRole_UserRoleId",
                table: "SuperUser");

            migrationBuilder.DropColumn(
                name: "XAxis",
                table: "Checkpoint");

            migrationBuilder.DropColumn(
                name: "YAxis",
                table: "Checkpoint");

            migrationBuilder.AlterColumn<int>(
                name: "UserRoleId",
                table: "SuperUser",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_SuperUser_UserRole_UserRoleId",
                table: "SuperUser",
                column: "UserRoleId",
                principalTable: "UserRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
