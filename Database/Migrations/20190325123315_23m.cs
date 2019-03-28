using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class _23m : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PhotoId",
                table: "Publication",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PublicationId",
                table: "Photo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Publication_PhotoId",
                table: "Publication",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_PublicationId",
                table: "Photo",
                column: "PublicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Publication_PublicationId",
                table: "Photo",
                column: "PublicationId",
                principalTable: "Publication",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Publication_Photo_PhotoId",
                table: "Publication",
                column: "PhotoId",
                principalTable: "Photo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Publication_PublicationId",
                table: "Photo");

            migrationBuilder.DropForeignKey(
                name: "FK_Publication_Photo_PhotoId",
                table: "Publication");

            migrationBuilder.DropIndex(
                name: "IX_Publication_PhotoId",
                table: "Publication");

            migrationBuilder.DropIndex(
                name: "IX_Photo_PublicationId",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "Publication");

            migrationBuilder.DropColumn(
                name: "PublicationId",
                table: "Photo");
        }
    }
}
