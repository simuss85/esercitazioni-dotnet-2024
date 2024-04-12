using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FotoGalleryMvcId.Data.Migrations
{
    /// <inheritdoc />
    public partial class AggiungeTipologia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Operazione",
                table: "Logs",
                newName: "OperazioneSvolta");

            migrationBuilder.AddColumn<bool>(
                name: "Tipologia",
                table: "Logs",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipologia",
                table: "Logs");

            migrationBuilder.RenameColumn(
                name: "OperazioneSvolta",
                table: "Logs",
                newName: "Operazione");
        }
    }
}
