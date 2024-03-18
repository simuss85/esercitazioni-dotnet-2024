using FoodexpRazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodexpRazor.Controllers;

public class StartController : Controller
{
    public static readonly Database _db = new();
    public static void InizializzaFrigo()
    {
        //creo categorie 
        List<Categoria> cateogrieDaAggiungere = new List<Categoria>
            {
                new Categoria { Nome = "latticini"},//1
                new Categoria { Nome = "salumi"},   //2
                new Categoria { Nome = "frutta"},   //3
                new Categoria { Nome = "verdura"},  //4
                new Categoria { Nome = "formaggi"}, //5
                new Categoria { Nome = "carne"},    //6
                new Categoria { Nome = "pesce"},    //7
                new Categoria { Nome = "bevande"}   //8
            };
        //creo lista alimenti
        List<Alimento> alimentiDaAggiungere = new List<Alimento>
            {
                new Alimento {Nome = "yogurt fragola", Quantita = 3, DataScadenza = new DateTime(2024, 3, 12), DataInserimento = DateTime.Today , CategoriaId = 1, Immagine = $"/img/yogurt-fragola.jpg"},
                new Alimento {Nome = "prosciutto cotto", Quantita = 1, DataScadenza = new DateTime(2024, 3, 3), DataInserimento = DateTime.Today , CategoriaId = 2, Immagine = $"/img/p-cotto.jpg"},
                new Alimento {Nome = "gorgonzola", Quantita = 1, DataScadenza = new DateTime(2024, 3, 31), DataInserimento = DateTime.Today , CategoriaId = 5, Immagine = $"/img/fridge.jpg"},
                new Alimento {Nome = "branzino", Quantita = 3, DataScadenza = new DateTime(2024, 3, 20), DataInserimento = DateTime.Today , CategoriaId = 7, Immagine = $"/img/fridge.jpg"},
                new Alimento {Nome = "salsiccia", Quantita = 4, DataScadenza = new DateTime(2024, 3, 28), DataInserimento = DateTime.Today , CategoriaId = 6, Immagine = $"/img/fridge.jpg"},
                new Alimento {Nome = "actimel", Quantita = 6, DataScadenza = new DateTime(2024, 3, 22), DataInserimento = DateTime.Today , CategoriaId = 1, Immagine = $"/img/fridge.jpg"},
                new Alimento {Nome = "succo ACE", Quantita = 2, DataScadenza = new DateTime(2024, 4, 24), DataInserimento = DateTime.Today , CategoriaId = 8, Immagine = $"/img/fridge.jpg"},
                new Alimento {Nome = "melanzane", Quantita = 3, DataScadenza = new DateTime(2024, 3, 16), DataInserimento = DateTime.Today , CategoriaId = 4, Immagine = $"/img/fridge.jpg"},
                new Alimento {Nome = "braciole", Quantita = 3, DataScadenza = new DateTime(2024, 3, 19), DataInserimento = DateTime.Today , CategoriaId = 6, Immagine = $"/img/fridge.jpg"},
                new Alimento {Nome = "insalata", Quantita = 1, DataScadenza = new DateTime(2024, 3, 17), DataInserimento = DateTime.Today , CategoriaId = 4, Immagine = $"/img/insalata.jpg"}

            };

        //creo utenti di prova
        List<Utente> utentiDaInserire = new List<Utente>
            {
                new Utente {Nome = "Simone", Password = "12345678" }, //1
                new Utente {Nome = "Emy", Password = "pongo89" },   //2
                new Utente {Nome = "Alex", Password = "maria99" }   //3
            };

        //creo lista listaAlimenti
        List<ListaSpesa> listaSpesaDaAggiungere = new List<ListaSpesa>
            {
                new ListaSpesa {Alimento = "insalata", Quantita = 1, CategoriaId = 4, UtenteId = 1},
                new ListaSpesa {Alimento = "salamino", Quantita = 3, CategoriaId = 2, UtenteId = 3},
                new ListaSpesa {Alimento = "parmigiano", Quantita = 1, CategoriaId = 5, UtenteId = 1},
                new ListaSpesa {Alimento = "orata", Quantita = 1, CategoriaId = 7, UtenteId = 2},
                new ListaSpesa {Alimento = "vino rosso", Quantita = 2, CategoriaId = 8, UtenteId = 3}
            };

        //aggiungo alimenti iniziali
        _db.Categorie.AddRange(cateogrieDaAggiungere);
        _db.SaveChanges();
        _db.Alimenti.AddRange(alimentiDaAggiungere);
        _db.SaveChanges();
        _db.Utenti.AddRange(utentiDaInserire);
        _db.SaveChanges();
        _db.ListaSpesa.AddRange(listaSpesaDaAggiungere);
        _db.SaveChanges();
    }
}