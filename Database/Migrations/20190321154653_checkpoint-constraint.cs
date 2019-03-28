using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class checkpointconstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsObsolete",
                table: "Checkpoints",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldNullable: true,
                oldDefaultValueSql: "0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsObsolete",
                table: "Checkpoints",
                nullable: true,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldDefaultValueSql: "0");
        }
    }
}
