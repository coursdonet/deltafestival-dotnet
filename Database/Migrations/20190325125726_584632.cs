using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class _584632 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuperUser_UserRole_UserRoleId",
                table: "SuperUser");

            migrationBuilder.DropIndex(
                name: "IX_Photo_PublicationId",
                table: "Photo");

            migrationBuilder.AlterColumn<int>(
                name: "UserRoleId",
                table: "SuperUser",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photo_PublicationId",
                table: "Photo",
                column: "PublicationId",
                unique: true,
                filter: "[PublicationId] IS NOT NULL");

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

            migrationBuilder.DropIndex(
                name: "IX_Photo_PublicationId",
                table: "Photo");

            migrationBuilder.AlterColumn<int>(
                name: "UserRoleId",
                table: "SuperUser",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Photo_PublicationId",
                table: "Photo",
                column: "PublicationId");

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
