using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class adding_duration_field_in_concert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Concert",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Concert");
        }
    }
}
