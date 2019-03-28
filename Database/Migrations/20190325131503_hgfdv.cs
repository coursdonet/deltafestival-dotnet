using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class hgfdv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Publication_PublicationId",
                table: "Photo");

            migrationBuilder.RenameColumn(
                name: "PublicationId",
                table: "Publication",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "PublicationId",
                table: "Photo",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Publication_PublicationId",
                table: "Photo",
                column: "PublicationId",
                principalTable: "Publication",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Publication_PublicationId",
                table: "Photo");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Publication",
                newName: "PublicationId");

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
                principalColumn: "PublicationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
