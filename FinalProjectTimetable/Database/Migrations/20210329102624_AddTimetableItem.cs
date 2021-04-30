using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class AddTimetableItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                 name: "Timetable",
                 columns: table => new
                 {
                     Id = table.Column<int>(type: "int", nullable: false)
                         .Annotation("SqlServer:Identity", "1, 1"),
                     TimetableItems = table.Column<string>(type: "nvarchar(max)", nullable: true),
                     UserId = table.Column<int>(type: "int", nullable: false)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_Timetable", x => x.Id);
                     table.ForeignKey("FK_User_UserId",
                         column: x => x.UserId,
                         principalTable: "Users",
                         principalColumn: "Id",
                         onDelete: ReferentialAction.Cascade);
                 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Timetable");
        }
    }
}
