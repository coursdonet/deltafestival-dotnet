using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class nbhjk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Publication_PublicationId",
                table: "Photo");

            migrationBuilder.DropIndex(
                name: "IX_Photo_PublicationId",
                table: "Photo");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Photo",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Publication_Id",
                table: "Photo",
                column: "Id",
                principalTable: "Publication",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Publication_Id",
                table: "Photo");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Photo",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
        }
    }
}
