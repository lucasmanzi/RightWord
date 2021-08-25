using Microsoft.EntityFrameworkCore.Migrations;

namespace RightWord.Data.Migrations
{
    public partial class StudentFields2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Session",
                table: "Student",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(120)");

            migrationBuilder.AlterColumn<int>(
                name: "CourseType",
                table: "Student",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(120)");

            migrationBuilder.AlterColumn<int>(
                name: "AccomodationDuration",
                table: "Student",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(120)");

            migrationBuilder.AlterColumn<int>(
                name: "Accomodation",
                table: "Student",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(120)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Session",
                table: "Student",
                type: "varchar(120)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "CourseType",
                table: "Student",
                type: "varchar(120)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "AccomodationDuration",
                table: "Student",
                type: "varchar(120)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Accomodation",
                table: "Student",
                type: "varchar(120)",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
