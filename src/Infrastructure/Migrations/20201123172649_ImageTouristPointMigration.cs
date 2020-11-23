using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class ImageTouristPointMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>("ImageTmp", "TouristPoints", "varbinary(max)");
            migrationBuilder.Sql("Update TouristPoints SET ImageTmp = CONVERT(varbinary, Image)");
            migrationBuilder.DropColumn("Image", "TouristPoints");
            migrationBuilder.RenameColumn("ImageTmp", "TouristPoints", "Image");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string> ("ImageTmp","TouristPoints", "nvarchar(max)");
            migrationBuilder.Sql("Update TouristPoints SET ImageTmp = CONVERT(nvarchar, Image)");
            migrationBuilder.DropColumn("Image", "TouristPoints");
            migrationBuilder.RenameColumn("ImageTmp", "TouristPoints", "Image");
        }
    }
}
