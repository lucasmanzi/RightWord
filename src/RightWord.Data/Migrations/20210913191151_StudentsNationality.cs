using Microsoft.EntityFrameworkCore.Migrations;

namespace RightWord.Data.Migrations
{
    public partial class StudentsNationality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Agency",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BusinessOwner",
                table: "Agency",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BusinessRegistration",
                table: "Agency",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Agency",
                type: "varchar(120)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LegalName",
                table: "Agency",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Agency",
                type: "varchar(40)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StudentsNationality",
                table: "Agency",
                type: "varchar(300)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Agency");

            migrationBuilder.DropColumn(
                name: "BusinessOwner",
                table: "Agency");

            migrationBuilder.DropColumn(
                name: "BusinessRegistration",
                table: "Agency");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Agency");

            migrationBuilder.DropColumn(
                name: "LegalName",
                table: "Agency");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Agency");

            migrationBuilder.DropColumn(
                name: "StudentsNationality",
                table: "Agency");
        }
    }
}
