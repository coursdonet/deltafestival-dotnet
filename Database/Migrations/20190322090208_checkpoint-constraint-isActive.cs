using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class checkpointconstraintisActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Checkpoints",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldDefaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Checkpoints",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldDefaultValueSql: "1");
        }
    }
}
