using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodexpMvc.Migrations
{
    /// <inheritdoc />
    public partial class ModificataEtichettaPwd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Pwd",
                table: "Utenti",
                newName: "Password");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Utenti",
                newName: "Pwd");
        }
    }
}
