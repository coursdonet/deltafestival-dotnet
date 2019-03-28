using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Checkpoints",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Longitude = table.Column<float>(nullable: false),
                    Latitude = table.Column<float>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    IsObsolete = table.Column<bool>(nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkpoints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mood",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mood", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    MembersCount = table.Column<int>(nullable: false),
                    WinDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Libelle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamCheckpoints",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TeamId = table.Column<int>(nullable: false),
                    CheckpointId = table.Column<int>(nullable: false),
                    TimeChecked = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamCheckpoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamCheckpoints_Checkpoints_CheckpointId",
                        column: x => x.CheckpointId,
                        principalTable: "Checkpoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamCheckpoints_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserRoleId = table.Column<int>(nullable: false),
                    MoodId = table.Column<int>(nullable: false),
                    TicketCode = table.Column<string>(maxLength: 50, nullable: true),
                    CanPublish = table.Column<bool>(nullable: false),
                    Demission = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Mood_MoodId",
                        column: x => x.MoodId,
                        principalTable: "Mood",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_UserRole_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "UserRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Publication",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    IsCoupDeCoeur = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publication", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publication_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserValidatedCheckpoints",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    CheckpointId = table.Column<int>(nullable: false),
                    TimeChecked = table.Column<DateTime>(nullable: false),
                    TeamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserValidatedCheckpoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserValidatedCheckpoints_Checkpoints_CheckpointId",
                        column: x => x.CheckpointId,
                        principalTable: "Checkpoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserValidatedCheckpoints_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserValidatedCheckpoints_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Publication_UserId",
                table: "Publication",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamCheckpoints_CheckpointId",
                table: "TeamCheckpoints",
                column: "CheckpointId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamCheckpoints_TeamId",
                table: "TeamCheckpoints",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_MoodId",
                table: "Users",
                column: "MoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRoleId",
                table: "Users",
                column: "UserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserValidatedCheckpoints_CheckpointId",
                table: "UserValidatedCheckpoints",
                column: "CheckpointId");

            migrationBuilder.CreateIndex(
                name: "IX_UserValidatedCheckpoints_TeamId",
                table: "UserValidatedCheckpoints",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_UserValidatedCheckpoints_UserId",
                table: "UserValidatedCheckpoints",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Publication");

            migrationBuilder.DropTable(
                name: "TeamCheckpoints");

            migrationBuilder.DropTable(
                name: "UserValidatedCheckpoints");

            migrationBuilder.DropTable(
                name: "Checkpoints");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Mood");

            migrationBuilder.DropTable(
                name: "UserRole");
        }
    }
}
