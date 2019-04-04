using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MembersCount",
                table: "Team",
                newName: "Point");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Point",
                table: "Team",
                newName: "MembersCount");
        }
    }
}
