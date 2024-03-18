# Cartella Models

La cartella "Models" contiene le classi che definiscono i modelli dei dati utilizzati dall'applicazione.  
Questi modelli rappresentano le entità principali con cui l'applicazione interagisce e sono fondamentali per la gestione e la manipolazione dei dati.  
Ogni classe modello contiene una serie di proprietà che rappresentano gli attributi e i dati associati all'entità che il modello rappresenta.  
I modelli sono utilizzati in varie parti dell'applicazione, inclusi i controller per elaborare le richieste, le view per visualizzare i dati e qualsiasi altra logica di business che coinvolge la gestione dei dati.

## UML CLASSI

```mermaid

---
title: namespace FoodexpMcv.Models
---
classDiagram
namespace Models{
    class Alimento{
        + int Id
        + string Nome
        + int Quantita
        + DateTime DataScadenza
        + DateTime DataInserimento
        + int CategoriaId
        + Categoria Categoria
        + string Info
    }

    class Categoria{
        + int Id
        + string Nome
    }

    class ListaSpesa{
        + int Id
        + string Alimento
        + int Quantita
        + int CategoriaId
        + Categoria Categoria
        + int UtenteId
        + Utente Utente
    }

    class Utente{
        + int Id
        + string Nome
        + string Password
        + List~ListaSpesa~ ListeSpesa
    }

    class Database{
        + DbSet~Utente~ Utenti
        + DbSet~Alimento~ Alimenti
        + DbSet~Categoria~ Categorie
        + DbSet~ListaSpesa~ ListaSpesa
        # OnConfiguring(DbContextOptionsBuilder optionsBuilder) void
    }

}
```