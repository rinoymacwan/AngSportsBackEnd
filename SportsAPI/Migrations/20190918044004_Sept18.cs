﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsAPI.Migrations
{
    public partial class Sept18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTestMapping",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Distance = table.Column<int>(nullable: true),
                    Time = table.Column<int>(nullable: true),
                    FitnessRating = table.Column<string>(nullable: true),
                    TId = table.Column<int>(nullable: false),
                    UId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTestMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTestMapping_Test_TId",
                        column: x => x.TId,
                        principalTable: "Test",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTestMapping_User_UId",
                        column: x => x.UId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTestMapping_TId",
                table: "UserTestMapping",
                column: "TId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTestMapping_UId",
                table: "UserTestMapping",
                column: "UId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTestMapping");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
