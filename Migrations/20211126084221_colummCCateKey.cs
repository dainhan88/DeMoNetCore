using Microsoft.EntityFrameworkCore.Migrations;

namespace DeMoMVCNetCore.Migrations
{
    public partial class colummCCateKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KeySearch",
                table: "Categories",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MovieGenre",
                table: "Categories",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KeySearch",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "MovieGenre",
                table: "Categories");
        }
    }
}
