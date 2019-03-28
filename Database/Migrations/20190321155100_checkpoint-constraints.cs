using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class checkpointconstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsObsolete",
                table: "Checkpoints",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldDefaultValueSql: "0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsObsolete",
                table: "Checkpoints",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldDefaultValue: false);
        }
    }
}
