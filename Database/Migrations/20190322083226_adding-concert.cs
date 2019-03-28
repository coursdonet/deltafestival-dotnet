using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class addingconcert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConcertLocation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Location = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcertLocation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Concert",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Artist = table.Column<string>(nullable: false),
                    Hour = table.Column<DateTime>(nullable: false),
                    ConcertLocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concert", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Concert_ConcertLocation_ConcertLocationId",
                        column: x => x.ConcertLocationId,
                        principalTable: "ConcertLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserConcerts",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    ConcertId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserConcerts", x => new { x.UserId, x.ConcertId });
                    table.ForeignKey(
                        name: "FK_UserConcerts_Concert_ConcertId",
                        column: x => x.ConcertId,
                        principalTable: "Concert",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserConcerts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Concert_ConcertLocationId",
                table: "Concert",
                column: "ConcertLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserConcerts_ConcertId",
                table: "UserConcerts",
                column: "ConcertId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserConcerts");

            migrationBuilder.DropTable(
                name: "Concert");

            migrationBuilder.DropTable(
                name: "ConcertLocation");
        }
    }
}
