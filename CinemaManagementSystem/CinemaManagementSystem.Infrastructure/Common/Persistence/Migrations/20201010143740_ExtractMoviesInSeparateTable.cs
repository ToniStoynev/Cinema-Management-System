using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaManagementSystem.Infrastructure.Common.Persistence.Migrations
{
    public partial class ExtractMoviesInSeparateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "DurationMinutes",
                table: "Movies",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Movies",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationMinutes",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Movies");
        }
    }
}
