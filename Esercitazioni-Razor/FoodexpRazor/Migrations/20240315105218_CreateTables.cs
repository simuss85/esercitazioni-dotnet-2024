using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodexpRazor.Migrations
{
    /// <inheritdoc />
    public partial class CreateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Almenti_Categorie_CategoriaId",
                table: "Almenti");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Almenti",
                table: "Almenti");

            migrationBuilder.RenameTable(
                name: "Almenti",
                newName: "Alimenti");

            migrationBuilder.RenameIndex(
                name: "IX_Almenti_CategoriaId",
                table: "Alimenti",
                newName: "IX_Alimenti_CategoriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alimenti",
                table: "Alimenti",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Utenti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utenti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListaSpesa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Alimento = table.Column<string>(type: "TEXT", nullable: true),
                    Quantita = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoriaId = table.Column<int>(type: "INTEGER", nullable: false),
                    UtenteId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaSpesa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListaSpesa_Categorie_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListaSpesa_Utenti_UtenteId",
                        column: x => x.UtenteId,
                        principalTable: "Utenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListaSpesa_CategoriaId",
                table: "ListaSpesa",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaSpesa_UtenteId",
                table: "ListaSpesa",
                column: "UtenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alimenti_Categorie_CategoriaId",
                table: "Alimenti",
                column: "CategoriaId",
                principalTable: "Categorie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alimenti_Categorie_CategoriaId",
                table: "Alimenti");

            migrationBuilder.DropTable(
                name: "ListaSpesa");

            migrationBuilder.DropTable(
                name: "Utenti");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alimenti",
                table: "Alimenti");

            migrationBuilder.RenameTable(
                name: "Alimenti",
                newName: "Almenti");

            migrationBuilder.RenameIndex(
                name: "IX_Alimenti_CategoriaId",
                table: "Almenti",
                newName: "IX_Almenti_CategoriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Almenti",
                table: "Almenti",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Almenti_Categorie_CategoriaId",
                table: "Almenti",
                column: "CategoriaId",
                principalTable: "Categorie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
