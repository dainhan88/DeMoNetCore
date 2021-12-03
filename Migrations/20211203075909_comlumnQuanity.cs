using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeMoMVCNetCore.Migrations
{
    public partial class comlumnQuanity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CategoryDate",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "quantity",
                table: "Categories",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryDate",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "quantity",
                table: "Categories");
        }
    }
}
