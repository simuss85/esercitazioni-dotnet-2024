public class Program
{
    static void Main(string[] args)
    {
        using (var db = new Database())
        {
            var clienti = new List<Cliente>
            {
                new Cliente { Nome = "Mario", Cognome = "Rossi", Telefono ="021046454" },    //crea nuovo cliente
                new Cliente { Nome = "Simone", Cognome = "Ussi", Telefono ="021046454" },
                new Cliente { Nome = "Simone", Cognome = "Ussi", Telefono ="021046454" }
            };
            db.InserisciClienti(clienti);
            db.StampaClienti();
        }
    }
}
