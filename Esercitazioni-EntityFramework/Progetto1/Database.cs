using Microsoft.EntityFrameworkCore;
public class Database : DbContext
{
    //crea una tabella in memoria utilizzando gli attributi classe
    public DbSet<Cliente> Clienti { get; set; }     //tabella clienti
    public DbSet<Prodotto> Prodotti { get; set; }   //tabella prodotti

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=MyDatabase.sqlite");  //gestito con DB Sqlite
        // optionsBuilder.UseInMemoryDatabase("MyDatabase");        //gestito in memoria
    }
    public void InserisciClienti(List<Cliente> clienti)
    {
        Clienti.AddRange(clienti);
        SaveChanges();
    }

    public void InserisciProdotti(List<Prodotto> prodotti)
    {
        Prodotti.AddRange(prodotti);
        SaveChanges();
    }

    public void StampaClienti()
    {
        var clienti = Clienti.Include(c => c.Prodotti).ToList();    //include e recupera i prodotti per cliente

        foreach (var c in clienti)
        {
            Console.WriteLine($"{c.Id} -  {c.Nome} {c.Cognome} (tel. {c.Telefono})");
            // Console.WriteLine("Prodotti acquistati:");
            foreach (var p in c.Prodotti!)
            {
                Console.WriteLine($"    {p.Id} - {p.Nome} - {p.Prezzo}");
            }
        }
    }

    public void StampaProdotti()
    {
        var prodotti = Prodotti.ToList();
        foreach (var p in prodotti)
        {
            Console.WriteLine($"{p.Id} - {p.Nome} - {p.Prezzo} - {p.Cliente!.Nome} - {p.Cliente.Cognome}");
        }
    }
}