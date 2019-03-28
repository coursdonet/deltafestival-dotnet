using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class iop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "Publication");

            migrationBuilder.AlterColumn<int>(
                name: "PublicationId",
                table: "Photo",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Publication_PublicationId",
                table: "Photo",
                column: "PublicationId",
                principalTable: "Publication",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Publication_PublicationId",
                table: "Photo");

            migrationBuilder.AddColumn<int>(
                name: "PhotoId",
                table: "Publication",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PublicationId",
                table: "Photo",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Publication_PhotoId",
                table: "Publication",
                column: "PhotoId");

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
    }
}
