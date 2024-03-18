# Cartella Controllers

La cartella "Controllers" contiene le classi che gestiscono il flusso di controllo dell'applicazione e coordinano le interazioni tra le view e i modelli.  
Queste classi implementano le operazioni CRUD (Create, Read, Update, Delete) per manipolare i dati dell'applicazione.  
Ogni classe controller è responsabile di rispondere alle richieste dell'utente provenienti dall'interfaccia utente o da altre fonti e di orchestrare le azioni necessarie per elaborare queste richieste.  
All'interno delle classi controller, vengono implementati metodi che corrispondono alle operazioni CRUD, come il recupero dei dati (Read), l'inserimento di nuovi record (Create), la modifica dei record esistenti (Update) e la rimozione dei record (Delete).  
Le classi svolgono un ruolo chiave nella gestione dell'interazione dell'utente con l'applicazione, nella definizione della logica di business e nell'elaborazione delle operazioni fondamentali per la gestione dei dati.

## UML CLASSI

```mermaid

---
title: namespace FoodexpMcv.Controllers
---
classDiagram
namespace Controllers{
    class Controller{
        - bool accesso$
        - bool eseguito$
        + Utente UtenteAttuale$
        # Database _db$
        + AvvioApp() void$
        - CreaUtenteAdmin()$ void
        - InizializzaFrigo()$ void
    }

    class UtentiController{
        UtentiController(Utente utenteAttuale)
        + SelezioneMenu()$ int
        + RegistraUtente()$ void
        + AggiungiUtenti(List~Utente~ utentiDaInserire)$ void
        - GetUtenti()$ List~string~
        + ModificaUtente()$ void
        - EliminaUtente()$ void
        + VerificaAccesso()$ bool
        - GetIdUtente(string nome, string password)$ int
        - CaricaUtente(int id, string nome, string password)$ void
    }

    class AlimentiController{
        - bool eseguito$
        + SelezioneMenu()$ void
        + SelezioneSottoMenu()$ void
        + AggiungiAlimento()$ void
        + AggiungiAlimenti(List~Alimento~ alimentiDaInserire)$ void
        + GetAlimenti()$ List~string~
        - GetListTipoAlimento()$ List~Alimento~
        + GetAlimentiScaduti(int range)$ List~string~
        + GetAlimentiEsaurimento(int range)$ List~string~
        + GetAlimentiPerNome(bool inverti)$ List~string~
        + GetAlimentiPerScadenza(bool inverti)$ List~string~
        + GetAlimentiPerInserimento(bool inverti)$ List~string~
        + GetAlimentiPerQuantita(bool inverti)$ List~string~
        + GetAlimentiPerCategoria(bool inverti)$ List~string~
        + ModificaAlimento()$ void
        - EliminaAlimento()$ bool
        - EliminaAlimentoPerId(int id)$ bool
    }

    class CategorieController{
        - bool eseguito$
        + SelezioneMenu()$ void
        + AggiungiCategoria()$ void
        + AggiungiCategorie(List~Categoria~ categorieDaInserire)$ void
        + GetCategorie()$ List~string~
        + ModificaCategoria()$ void
    }

    class ListaSpesaController{
        - bool eseguito$
        + SelezioneMenu()$ void
        + AggiungiInListaSpesa()$ void
        + AggiungiListaSpesa(List~ListaSpesa~ listaSpesaDaAggiungere)$ void
        + GetLista()$ List~string~
        + ModificaListaSpesa()$ void
        - EliminaDaListaSpesa()$ void
        - EliminaDaListaPerId(int id)$ void
    }
    class ValidaInput{
        + GetString(int left, int top)$ string
        + GetData(int left, int top)$ DateTime
        + GetQuantita(int left, int top)$ int
        + GetIntElenco(int totaleElenco, int left, int top, bool opzioneRoE)$ int
        + GetSiNo(int left, int top)$ string
    }
}
    Controller <.. UtentiController : extend
    Controller <.. AlimentiController : extend
    Controller <.. CategorieController : extend
    Controller <.. ListaSpesaController : extend

```