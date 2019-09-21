using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsAPI.Migrations
{
    public partial class Sept18_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FitnessRating",
                table: "UserTestMapping");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FitnessRating",
                table: "UserTestMapping",
                nullable: true);
        }
    }
}
