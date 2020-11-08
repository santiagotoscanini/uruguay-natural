using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class LodgingsWithPriceMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CalculatedPrice",
                table: "Lodgings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CalculatedPrice",
                table: "Lodgings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
