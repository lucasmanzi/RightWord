using Microsoft.EntityFrameworkCore.Migrations;

namespace RightWord.Data.Migrations
{
    public partial class ChangeSurname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SurName",
                table: "Student",
                newName: "Surname");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Student",
                newName: "SurName");
        }
    }
}
