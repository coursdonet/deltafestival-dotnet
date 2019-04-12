using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class changeconcert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserConcerts",
                table: "UserConcerts");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserConcerts",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserConcerts",
                table: "UserConcerts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserConcerts_UserId",
                table: "UserConcerts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserConcerts",
                table: "UserConcerts");

            migrationBuilder.DropIndex(
                name: "IX_UserConcerts_UserId",
                table: "UserConcerts");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserConcerts",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserConcerts",
                table: "UserConcerts",
                columns: new[] { "UserId", "ConcertId" });
        }
    }
}
