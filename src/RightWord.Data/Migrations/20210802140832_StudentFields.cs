using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RightWord.Data.Migrations
{
    public partial class StudentFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Student");

            migrationBuilder.AddColumn<string>(
                name: "Accomodation",
                table: "Student",
                type: "varchar(120)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AccomodationDuration",
                table: "Student",
                type: "varchar(120)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ArrivalDate",
                table: "Student",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Student",
                type: "varchar(120)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CourseType",
                table: "Student",
                type: "varchar(120)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Dob",
                table: "Student",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Student",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishDate",
                table: "Student",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "NativeLanguage",
                table: "Student",
                type: "varchar(120)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Passport",
                table: "Student",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Session",
                table: "Student",
                type: "varchar(120)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Student",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Agency",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Agency",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accomodation",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "AccomodationDuration",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "ArrivalDate",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "CourseType",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Dob",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "FinishDate",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "NativeLanguage",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Passport",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Session",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Agency");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Agency");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Student",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
