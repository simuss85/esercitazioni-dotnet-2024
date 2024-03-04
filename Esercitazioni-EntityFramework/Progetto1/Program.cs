public class Program
{
    static void Main(string[] args)
    {
        using (var db = new Database())
        {
            var clienti = new List<Cliente>
            {
                new Cliente { Nome = "Mario", Cognome = "Rossi", Telefono ="021046454" },   //crea nuovo cliente
                new Cliente { Nome = "Simone", Cognome = "Ussi", Telefono ="021046454" },   //crea nuovo cliente
                new Cliente { Nome = "Alex", Cognome = "Bruno", Telefono ="021046454" }    //crea nuovo cliente
            };
            Console.WriteLine("clienti");
            db.InserisciClienti(clienti);
            db.StampaClienti();

            var prodotti = new List<Prodotto>
            {
                new Prodotto { Nome = "prodotto1", Prezzo = 10, ClienteId = 1 },
                new Prodotto { Nome = "prodotto2", Prezzo = 20, ClienteId = 1 },
                new Prodotto { Nome = "prodotto3", Prezzo = 30, ClienteId = 2 },
                new Prodotto { Nome = "prodotto4", Prezzo = 40, ClienteId = 2 },
                new Prodotto { Nome = "prodotto5", Prezzo = 50, ClienteId = 3 },
                new Prodotto { Nome = "prodotto6", Prezzo = 70, ClienteId = 3 }
            };
            Console.WriteLine("prodotti per cliente");
            db.InserisciProdotti(prodotti);
            db.StampaProdotti();

            var ordini = new List<Ordine>
            {
                new Ordine { ProdottoId = 1},
                new Ordine { ProdottoId = 2},
                new Ordine { ProdottoId = 3},
                new Ordine { ProdottoId = 4},
                new Ordine { ProdottoId = 5},
                new Ordine { ProdottoId = 6},
            };
            Console.WriteLine("ordini");
            db.InserisciOrdini(ordini);
            db.StampaOrdini();
        }
    }
}
