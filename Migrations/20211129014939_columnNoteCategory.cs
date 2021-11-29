using Microsoft.EntityFrameworkCore.Migrations;

namespace DeMoMVCNetCore.Migrations
{
    public partial class columnNoteCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Categorynote",
                table: "Categories",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categorynote",
                table: "Categories");
        }
    }
}
