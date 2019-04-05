using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class addingmood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MoodValue",
                table: "Mood",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MoodValue",
                table: "Mood");
        }
    }
}
