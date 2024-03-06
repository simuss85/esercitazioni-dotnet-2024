using Microsoft.EntityFrameworkCore;
public class Database : DbContext
{
    //crea una tabella in memoria utilizzando gli attributi classe
    public DbSet<Cliente> Clienti { get; set; }     //tabella clienti
    public DbSet<Prodotto> Prodotti { get; set; }   //tabella prodotti
    public DbSet<Ordine> Ordini { get; set; }       //tabella ordini

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // string connection = "server=localhost;user=root;password=1234;database=myDatabaseMariaDB";
        // optionsBuilder.UseMySql(connection, ServerVersion.AutoDetect(connection));
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

    public void InserisciOrdini(List<Ordine> ordini)
    {
        Ordini.AddRange(ordini);
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

    public void StampaOrdini()
    {
        var ordini = Ordini.Include(o => o.Prodotto).ThenInclude(p => p!.Cliente).ToList();
        foreach (var o in Ordini)
        {
            Console.WriteLine($"{o.Id} - {o.Prodotto!.Nome} - {o.Prodotto.Cliente!.Nome} {o.Prodotto.Cliente.Cognome}");
        }
    }
}