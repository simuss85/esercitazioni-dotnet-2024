using Microsoft.EntityFrameworkCore;
namespace FoodexpRazor.Models;

public class Database : DbContext
{
    public DbSet<Utente> Utenti { get; set; }
    public DbSet<Alimento> Alimenti { get; set; }
    public DbSet<Categoria> Categorie { get; set; }
    public DbSet<ListaSpesa> ListaSpesa { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Data/database.sqlite");
    }
}