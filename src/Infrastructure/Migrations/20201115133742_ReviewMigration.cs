using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class ReviewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Lodgings_LodgingId",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "TouristReviewId",
                table: "Bookings",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(nullable: true),
                    NumberOfPoints = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TouristReviewId",
                table: "Bookings",
                column: "TouristReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Lodgings_LodgingId",
                table: "Bookings",
                column: "LodgingId",
                principalTable: "Lodgings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Review_TouristReviewId",
                table: "Bookings",
                column: "TouristReviewId",
                principalTable: "Review",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Lodgings_LodgingId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Review_TouristReviewId",
                table: "Bookings");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_TouristReviewId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "TouristReviewId",
                table: "Bookings");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Lodgings_LodgingId",
                table: "Bookings",
                column: "LodgingId",
                principalTable: "Lodgings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
