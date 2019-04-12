using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class changeconcert1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserConcerts_User_UserId",
                table: "UserConcerts");
            

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserConcerts");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserConcerts",
                newName: "UserConcertId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserConcertId",
                table: "UserConcerts",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserConcerts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserConcerts_UserId",
                table: "UserConcerts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserConcerts_User_UserId",
                table: "UserConcerts",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
