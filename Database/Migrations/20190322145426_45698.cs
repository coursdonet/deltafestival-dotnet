using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class _45698 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuperUser_UserRole_UserRoleId",
                table: "SuperUser");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddForeignKey(
                name: "FK_SuperUser_UserRole_UserRoleId",
                table: "SuperUser",
                column: "UserRoleId",
                principalTable: "UserRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
