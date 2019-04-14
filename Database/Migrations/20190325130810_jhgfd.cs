using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class jhgfd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Photo_PublicationId",
                table: "Photo");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_PublicationId",
                table: "Photo",
                column: "PublicationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Photo_PublicationId",
                table: "Photo");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_PublicationId",
                table: "Photo",
                column: "PublicationId",
                unique: true,
                filter: "[PublicationId] IS NOT NULL");
        }
    }
}
