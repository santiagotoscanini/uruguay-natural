using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class LodgingsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Tourist_TouristId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_TouristPoint_Region_RegionName",
                table: "TouristPoint");

            migrationBuilder.DropForeignKey(
                name: "FK_TouristPointCategory_TouristPoint_TouristPointId",
                table: "TouristPointCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TouristPoint",
                table: "TouristPoint");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Booking",
                table: "Booking");

            migrationBuilder.RenameTable(
                name: "TouristPoint",
                newName: "TouristPoints");

            migrationBuilder.RenameTable(
                name: "Booking",
                newName: "Bookings");

            migrationBuilder.RenameIndex(
                name: "IX_TouristPoint_RegionName",
                table: "TouristPoints",
                newName: "IX_TouristPoints_RegionName");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_TouristId",
                table: "Bookings",
                newName: "IX_Bookings_TouristId");

            migrationBuilder.AddColumn<int>(
                name: "LodgingId",
                table: "Bookings",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TouristPoints",
                table: "TouristPoints",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                column: "Code");

            migrationBuilder.CreateTable(
                name: "Lodgings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    NumberOfStars = table.Column<int>(nullable: false),
                    TouristPointId = table.Column<int>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Images = table.Column<string>(nullable: true),
                    CostPerNight = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    DescriptionForBookings = table.Column<string>(nullable: true),
                    MaximumSize = table.Column<int>(nullable: false),
                    CurrentlyOccupiedPlaces = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lodgings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lodgings_TouristPoints_TouristPointId",
                        column: x => x.TouristPointId,
                        principalTable: "TouristPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_LodgingId",
                table: "Bookings",
                column: "LodgingId");

            migrationBuilder.CreateIndex(
                name: "IX_Lodgings_TouristPointId",
                table: "Lodgings",
                column: "TouristPointId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Lodgings_LodgingId",
                table: "Bookings",
                column: "LodgingId",
                principalTable: "Lodgings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Tourist_TouristId",
                table: "Bookings",
                column: "TouristId",
                principalTable: "Tourist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TouristPointCategory_TouristPoints_TouristPointId",
                table: "TouristPointCategory",
                column: "TouristPointId",
                principalTable: "TouristPoints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TouristPoints_Region_RegionName",
                table: "TouristPoints",
                column: "RegionName",
                principalTable: "Region",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Lodgings_LodgingId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Tourist_TouristId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_TouristPointCategory_TouristPoints_TouristPointId",
                table: "TouristPointCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_TouristPoints_Region_RegionName",
                table: "TouristPoints");

            migrationBuilder.DropTable(
                name: "Lodgings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TouristPoints",
                table: "TouristPoints");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_LodgingId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "LodgingId",
                table: "Bookings");

            migrationBuilder.RenameTable(
                name: "TouristPoints",
                newName: "TouristPoint");

            migrationBuilder.RenameTable(
                name: "Bookings",
                newName: "Booking");

            migrationBuilder.RenameIndex(
                name: "IX_TouristPoints_RegionName",
                table: "TouristPoint",
                newName: "IX_TouristPoint_RegionName");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_TouristId",
                table: "Booking",
                newName: "IX_Booking_TouristId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TouristPoint",
                table: "TouristPoint",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Booking",
                table: "Booking",
                column: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Tourist_TouristId",
                table: "Booking",
                column: "TouristId",
                principalTable: "Tourist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TouristPoint_Region_RegionName",
                table: "TouristPoint",
                column: "RegionName",
                principalTable: "Region",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TouristPointCategory_TouristPoint_TouristPointId",
                table: "TouristPointCategory",
                column: "TouristPointId",
                principalTable: "TouristPoint",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
