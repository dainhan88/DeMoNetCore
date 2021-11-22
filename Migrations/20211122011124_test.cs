using Microsoft.EntityFrameworkCore.Migrations;

namespace DeMoMVCNetCore.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EplID",
                table: "people",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EplName",
                table: "people",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HiHi",
                columns: table => new
                {
                    HiHiId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HiHIname = table.Column<string>(type: "TEXT", nullable: true),
                    CategoryID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HiHi", x => x.HiHiId);
                    table.ForeignKey(
                        name: "FK_HiHi_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HiHi_CategoryID",
                table: "HiHi",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HiHi");

            migrationBuilder.DropColumn(
                name: "EplID",
                table: "people");

            migrationBuilder.DropColumn(
                name: "EplName",
                table: "people");
        }
    }
}
