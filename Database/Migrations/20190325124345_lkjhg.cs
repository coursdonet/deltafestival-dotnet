using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class lkjhg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Publication",
                newName: "PublicationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PublicationId",
                table: "Publication",
                newName: "Id");
        }
    }
}
