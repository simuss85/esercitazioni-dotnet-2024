using Microsoft.EntityFrameworkCore;

namespace FoodexpMvc.Models
{
    public class Database : DbContext
    {
        public DbSet<Utente> Utenti { get; set; }
        public DbSet<Categoria> Categorie { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Data/database.sqlite");
        }
    }
}