using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class GuestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CalculatedPrice",
                table: "Lodgings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Guest",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Percentage = table.Column<int>(nullable: false),
                    MinRankAge = table.Column<int>(nullable: false),
                    MaxRankAge = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guest", x => x.Name);
                });
            
            migrationBuilder.CreateTable(
                name: "Administrators",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrators", x => x.Email);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guest");

            migrationBuilder.DropColumn(
                name: "CalculatedPrice",
                table: "Lodgings");
        }
    }
}
