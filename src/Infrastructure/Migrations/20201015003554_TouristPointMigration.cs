using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class TouristPointMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TouristPoint",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TouristPoint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TouristPoint_Region_RegionName",
                        column: x => x.RegionName,
                        principalTable: "Region",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TouristPointCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true),
                    TouristPointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TouristPointCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TouristPointCategory_Category_CategoryName",
                        column: x => x.CategoryName,
                        principalTable: "Category",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TouristPointCategory_TouristPoint_TouristPointId",
                        column: x => x.TouristPointId,
                        principalTable: "TouristPoint",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TouristPoint_RegionName",
                table: "TouristPoint",
                column: "RegionName");

            migrationBuilder.CreateIndex(
                name: "IX_TouristPointCategory_CategoryName",
                table: "TouristPointCategory",
                column: "CategoryName");

            migrationBuilder.CreateIndex(
                name: "IX_TouristPointCategory_TouristPointId",
                table: "TouristPointCategory",
                column: "TouristPointId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TouristPointCategory");

            migrationBuilder.DropTable(
                name: "TouristPoint");
        }
    }
}
