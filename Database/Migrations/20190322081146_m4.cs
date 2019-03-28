using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class m4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserRoleId",
                table: "SuperUser",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SuperUser_UserRoleId",
                table: "SuperUser",
                column: "UserRoleId");

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

            migrationBuilder.DropIndex(
                name: "IX_SuperUser_UserRoleId",
                table: "SuperUser");

            migrationBuilder.DropColumn(
                name: "UserRoleId",
                table: "SuperUser");
        }
    }
}
