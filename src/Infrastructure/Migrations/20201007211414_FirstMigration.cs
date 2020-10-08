using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tourist",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tourist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Code = table.Column<string>(nullable: false),
                    TouristId = table.Column<int>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CheckInDate = table.Column<DateTime>(nullable: false),
                    CheckOutDate = table.Column<DateTime>(nullable: false),
                    NumberOfGuests = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Booking_Tourist_TouristId",
                        column: x => x.TouristId,
                        principalTable: "Tourist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_TouristId",
                table: "Booking",
                column: "TouristId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Tourist");
        }
    }
}
