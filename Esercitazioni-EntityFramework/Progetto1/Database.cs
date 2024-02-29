using Microsoft.EntityFrameworkCore;
public class Database : DbContext
{
    //crea una tabella in memoria utilizzando gli attributi della classe Clienti
    public DbSet<Cliente> Clienti { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("MyDatabase");
    }

    public void InserisciClienti(List<Cliente> clienti)
    {
        Clienti.AddRange(clienti);
        SaveChanges();
    }

    public void StampaClienti()
    {
        var clienti = Clienti.ToList();
        foreach (var c in clienti)
        {
            Console.WriteLine($"{c.Id} -  {c.Nome} {c.Cognome} (tel. {c.Telefono})");
        }
    }
}