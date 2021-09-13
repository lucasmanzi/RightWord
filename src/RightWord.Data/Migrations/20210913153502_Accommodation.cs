using Microsoft.EntityFrameworkCore.Migrations;

namespace RightWord.Data.Migrations
{
    public partial class Accommodation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accomodation",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "AccomodationDuration",
                table: "Student");

            migrationBuilder.AddColumn<int>(
                name: "Accommodation",
                table: "Student",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AccommodationDuration",
                table: "Student",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accommodation",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "AccommodationDuration",
                table: "Student");

            migrationBuilder.AddColumn<int>(
                name: "Accomodation",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AccomodationDuration",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
