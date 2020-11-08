using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class NumberOfGuestsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfGuests",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "TotalNumberOfGuests",
                table: "Bookings",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalNumberOfGuests",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfGuests",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
