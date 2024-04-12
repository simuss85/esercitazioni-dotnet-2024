using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FotoGalleryMvcId.Data.Migrations
{
    /// <inheritdoc />
    public partial class AggiungeDataRegistrazione : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataRegistrazione",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataRegistrazione",
                table: "AspNetUsers");
        }
    }
}
