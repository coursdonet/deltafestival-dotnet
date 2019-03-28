using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class checkpointconstraintdfValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Checkpoints",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValueSql: "1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Checkpoints",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(bool));
        }
    }
}
