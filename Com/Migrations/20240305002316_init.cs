using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Com.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phonenumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Is_visible = table.Column<bool>(type: "bit", nullable: false),
                    TimeOfPublish = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imagepath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Is_visible = table.Column<bool>(type: "bit", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserImages_UserInfos_IdUser",
                        column: x => x.IdUser,
                        principalTable: "UserInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserStates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Room_1 = table.Column<bool>(type: "bit", nullable: false),
                    Room_2 = table.Column<bool>(type: "bit", nullable: false),
                    Room_3 = table.Column<bool>(type: "bit", nullable: false),
                    Room_4 = table.Column<bool>(type: "bit", nullable: false),
                    Room_Final = table.Column<bool>(type: "bit", nullable: false),
                    FinalState = table.Column<bool>(type: "bit", nullable: false),
                    Is_visible = table.Column<bool>(type: "bit", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserStates_UserInfos_IdUser",
                        column: x => x.IdUser,
                        principalTable: "UserInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserImages_IdUser",
                table: "UserImages",
                column: "IdUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserStates_IdUser",
                table: "UserStates",
                column: "IdUser",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserImages");

            migrationBuilder.DropTable(
                name: "UserStates");

            migrationBuilder.DropTable(
                name: "UserInfos");
        }
    }
}
