﻿using System.Data.SQLite;
using Spectre.Console;

/// <summary>
/// Programma di base per la gestione degli alimenti nel frigorifero tramite utilizzo
/// di database SQLite. <br/>
/// Utilizza tre tabelle: <br/>
/// - <b>alimenti</b>: elenco di tutti gli alimenti nel frigorifero 
/// - <b>categorie</b>: le categorie di alimenti presenti nel frigorifero
/// - <b>utenti</b>: la lista di utenti utilizzatori dell'app
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        string utente;
        string selezione;   //scelta utente dei menù
        bool eseguito; //per la gestione del sotto-menu

        InizializzaApp();
        utente = CreaUtente();

        while (true)
        {
            Console.Clear();

            Console.WriteLine($"Ciao {utente}\n");
            MenuPrincipale();
            //richiesta selezione
            Console.Write("Scegli un opzione: ");
            selezione = Console.ReadLine()!;
            Thread.Sleep(500);

            Console.Clear();

            switch (selezione)
            {
                case "1":
                    CreaFrigorifero();
                    break;

                case "2":   //visualizza alimenti
                    eseguito = false;
                    while (!eseguito)
                    {
                        Console.Clear();
                        Console.WriteLine("Visualizza alimenti\n");
                        MenuVisualizzaAlimenti();
                        //richiesta selezione
                        Console.Write("Scegli un opzione: ");
                        selezione = Console.ReadLine()!;
                        Thread.Sleep(500);

                        Console.Clear();

                        switch (selezione)
                        {
                            case "1":
                                Console.WriteLine("Lista completa\n");
                                VisualizzaAlimenti();
                                Console.WriteLine("\npremi un tasto...");
                                Console.ReadKey();
                                break;

                            case "2":
                                Console.WriteLine("Scaduti\n");
                                VisualizzaScaduti();
                                Console.WriteLine("\npremi un tasto...");
                                Console.ReadKey();
                                break;

                            case "3":
                                Console.WriteLine("In esaurimento\n");
                                VisualizzaInEsaurimento();
                                Console.WriteLine("\npremi un tasto...");
                                Console.ReadKey();
                                break;

                            case "4":
                                Console.WriteLine("Ordine alfabetico\n");
                                VisualizzaPerNome();
                                Console.WriteLine("\npremi un tasto...");
                                Console.ReadKey();
                                break;

                            case "5":
                                Console.WriteLine("Ordine per scadenza\n");
                                VisualizzaPerDataScadenza();
                                Console.WriteLine("\npremi un tasto...");
                                Console.ReadKey();
                                break;

                            case "6":
                                Console.WriteLine("Ordine per data inserimento\n");
                                VisualizzaPerDataInserimento();
                                Console.WriteLine("\npremi un tasto...");
                                Console.ReadKey();
                                break;

                            case "7":
                                Console.WriteLine("Ordine per categoria\n");
                                VisualizzaPerCategoria();
                                Console.WriteLine("\npremi un tasto...");
                                Console.ReadKey();
                                break;

                            case "8":
                                Console.WriteLine("Torno al menu principale");
                                Thread.Sleep(500);
                                eseguito = true;
                                break;

                            default:
                                Console.WriteLine("Errore di inserimento");
                                break;
                        }
                    }
                    break;

                case "3":   //lista della spesa
                    eseguito = false;
                    while (!eseguito)
                    {
                        Console.Clear();
                        Console.WriteLine("Lista della spesa\n");
                        MenuListaSpesa();
                        //richiesta selezione
                        Console.Write("Scegli un opzione: ");
                        selezione = Console.ReadLine()!;
                        Thread.Sleep(500);

                        Console.Clear();

                        switch (selezione)
                        {
                            case "1":
                                VisualizzaListaSpesa();
                                Console.WriteLine("\npremi un tasto...");
                                Console.ReadKey();
                                break;

                            case "2":
                                InserisciAListaSpesa(utente);
                                Console.WriteLine("\npremi un tasto...");
                                Console.ReadKey();
                                break;

                            case "3":
                                ModificaListaSpesa();
                                Console.WriteLine("\npremi un tasto...");
                                Console.ReadKey();
                                break;

                            case "4":
                                EliminaInListaSpesa();
                                Console.WriteLine("\npremi un tasto...");
                                Console.ReadKey();
                                break;

                            case "5":
                                Console.WriteLine("Torno al menu principale");
                                Thread.Sleep(500);
                                eseguito = true;
                                break;

                            default:
                                Console.WriteLine("Errore di inserimento");
                                break;
                        }
                    }
                    break;

                case "4":  //gestisci alimenti
                    eseguito = false;
                    while (!eseguito)
                    {
                        Console.Clear();
                        Console.WriteLine("Gestisci alimenti\n");
                        MenuAlimenti();
                        //richiesta selezione
                        Console.Write("Scegli un opzione: ");
                        selezione = Console.ReadLine()!;
                        Thread.Sleep(500);

                        Console.Clear();

                        switch (selezione)
                        {
                            case "1":
                                InserisciAlimento();
                                Console.WriteLine("\npremi un tasto...");
                                Console.ReadKey();
                                break;

                            case "2":
                                ModificaAlimento();
                                Console.WriteLine("\npremi un tasto...");
                                Console.ReadKey();
                                break;

                            case "3":
                                EliminaAlimento();
                                Console.WriteLine("\npremi un tasto...");
                                Console.ReadKey();
                                break;

                            case "4":
                                Console.WriteLine("Torno al menu principale");
                                Thread.Sleep(500);
                                eseguito = true;
                                break;

                            default:
                                Console.WriteLine("Errore di inserimento");
                                break;
                        }
                    }
                    break;

                case "5":  //gestisci categorie
                    eseguito = false;
                    while (!eseguito)
                    {
                        Console.Clear();
                        Console.WriteLine("Gestisci categorie\n");
                        MenuCategorie();
                        //richiesta selezione
                        Console.Write("Scegli un opzione: ");
                        selezione = Console.ReadLine()!;
                        Thread.Sleep(500);

                        Console.Clear();

                        switch (selezione)
                        {
                            case "1":
                                VisualizzaCategorie();
                                Console.WriteLine("\npremi un tasto...");
                                Console.ReadKey();
                                break;

                            case "2":
                                ModificaCategoria();
                                Console.WriteLine("\npremi un tasto...");
                                Console.ReadKey();
                                break;

                            case "3":
                                EliminaCategoria();
                                Console.WriteLine("\npremi un tasto...");
                                Console.ReadKey();
                                break;

                            case "4":
                                Console.WriteLine("Torno al menu principale");
                                Thread.Sleep(500);
                                eseguito = true;
                                break;

                            default:
                                Console.WriteLine("Errore di inserimento");
                                break;
                        }
                    }
                    break;

                case "6":  //gestisci untenti
                    eseguito = false;
                    while (!eseguito)
                    {
                        Console.Clear();
                        Console.WriteLine("Gestisci utenti\n");
                        MenuUtenti();
                        //richiesta selezione
                        Console.Write("Scegli un opzione: ");
                        selezione = Console.ReadLine()!;
                        Thread.Sleep(500);

                        Console.Clear();

                        switch (selezione)
                        {
                            case "1":
                                VisualizzaUtenti();
                                Console.WriteLine("\npremi un tasto...");
                                Console.ReadKey();
                                break;

                            case "2":
                                ModificaUtente();
                                Console.WriteLine("\npremi un tasto...");
                                Console.ReadKey();
                                break;

                            case "3":
                                EliminaUtente();
                                Console.WriteLine("\npremi un tasto...");
                                Console.ReadKey();
                                break;

                            case "4":
                                Console.WriteLine("Torno al menu principale");
                                Thread.Sleep(500);
                                eseguito = true;
                                break;

                            default:
                                Console.WriteLine("Errore di inserimento");
                                break;
                        }
                    }
                    break;

                case "7":  //Esci
                    Console.WriteLine("Arrivederci");
                    Thread.Sleep(800);
                    return;

                default:
                    Console.WriteLine("Errore di inserimento");
                    break;
            }
        }
    }

    #region MENU 
    /// <summary>
    /// Crea il menu di avvio dell'applicazione
    /// </summary>
    static void MenuPrincipale()
    {
        Console.WriteLine("1 - Crea un frigorifero");
        Console.WriteLine("2 - Visualizza alimenti");
        Console.WriteLine("3 - Lista della spesa");
        Console.WriteLine("4 - Gestisci alimenti");
        Console.WriteLine("5 - Gestisci categorie");
        Console.WriteLine("6 - Gestisci utenti");
        Console.WriteLine("7 - Esci");
    }

    /// <summary>
    /// Crea il sotto-menu per la visualizzazione degli alimenti
    /// </summary>
    static void MenuVisualizzaAlimenti()
    {
        Console.WriteLine("1 - Visualizza tutti");
        Console.WriteLine("2 - Visualizza scaduti");
        Console.WriteLine("3 - Visualizza in esaurimento");
        Console.WriteLine("4 - Ordina per nome");
        Console.WriteLine("5 - Ordina per data di scadenza");
        Console.WriteLine("6 - Ordina per data di inserimento");
        Console.WriteLine("7 - Ordina per categoria");
        Console.WriteLine("8 - Torna al menu principale");
    }

    /// <summary>
    /// Crea il sotto-menu per la lista della spesa
    /// </summary>
    static void MenuListaSpesa()
    {
        Console.WriteLine("1 - Visualizza");
        Console.WriteLine("2 - Aggiungi alimento");
        Console.WriteLine("3 - Modifica alimento");
        Console.WriteLine("4 - Elimina alimento");
        Console.WriteLine("5 - Torna al menu principale");
    }

    /// <summary>
    /// Crea il sotto-menu per la gestione degli alimenti
    /// </summary>
    static void MenuAlimenti()
    {
        Console.WriteLine("1 - Inserisci un alimento");
        Console.WriteLine("2 - Modifica un alimento");
        Console.WriteLine("3 - Elimina un alimento");
        Console.WriteLine("4 - Torna al menu principale");
    }

    /// <summary>
    /// Crea il sotto-menu per la gestione delle categorie alimenti
    /// </summary>
    static void MenuCategorie()
    {
        Console.WriteLine("1 - Visualizza categorie");
        Console.WriteLine("2 - Modifica una categoria");
        Console.WriteLine("3 - Elimina una categoria");
        Console.WriteLine("4 - Torna al menu principale");
    }

    /// <summary>
    /// Crea il sotto-menu per la gestione degli utenti dell'applicazione
    /// </summary>
    static void MenuUtenti()
    {
        Console.WriteLine("1 - Visualizza utenti");
        Console.WriteLine("2 - Modifica un utente");
        Console.WriteLine("3 - Elimina un utente");
        Console.WriteLine("4 - Torna al menu principale");
    }
    #endregion

    #region METODI MENU PRINCIPALE

    /// <summary>
    /// Crea le cartelle, il database, le tabelle e inserisce l'utente attuale nella tabella utenti
    /// </summary>
    /// <returns>Il nome dell'utente attuale di tipo string</returns>
    static void InizializzaApp()
    {
        string dirDb = @"data";     //path cartella del database
        string path = @"data/database.db";

        //controllo la directory del database
        if (!Directory.Exists(dirDb))
        {
            Directory.CreateDirectory(dirDb);
        }

        //controllo il file database.db se non presente lo creo
        if (!File.Exists(path))
        {
            SQLiteConnection.CreateFile(path);
            SQLiteConnection connection = new($"Data Source={path}; Version=3;");
            //apro la connessione al db
            connection.Open();
            //creo struttura db
            string sql = @"
                           CREATE TABLE utenti (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE);
                           CREATE TABLE listaSpesa (id INTEGER PRIMARY KEY AUTOINCREMENT, alimento TEXT, quantita INTEGER CHECK (quantita > 0), id_utente INTEGER, FOREIGN KEY (id_utente) REFERENCES utenti(id));
                           CREATE TABLE categorie (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT);
                           CREATE TABLE alimenti (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT, quantita INTEGER CHECK (quantita > 0), data_inserimento DATE, data_scadenza DATE, id_categoria INTEGER, FOREIGN KEY (id_categoria) REFERENCES categorie(id));
                           ";
            SQLiteCommand command = new(sql, connection);
            command.ExecuteNonQuery();
            //chiudo la connessione
            connection.Close();
        }

    }

    /// <summary>
    /// Permette di creare un nuovo utente o di gestire uno gia presente
    /// </summary>
    /// <returns>La stringa del nome utente attuale</returns>
    static string CreaUtente()
    {
        //apro la connessione
        SQLiteConnection connection = new($"Data Source=data/database.db; Version=3");
        connection.Open();

        string nome;
        bool eseguito = false;

        Console.WriteLine("Inserisci il tuo nome: ");
        nome = Console.ReadLine()!;

        //ricerca nella tebella utenti
        string sql = "SELECT nome FROM utenti;";
        SQLiteCommand command = new(sql, connection);
        //leggo il contenuto della tabella utenti
        SQLiteDataReader reader = command.ExecuteReader();

        while (reader.Read())   //verifico se il nome non è gia inserito
        {
            if ($"{reader["nome"]}" == nome)
            {
                Console.WriteLine($"Ciao {reader["nome"]}!!!");
                Console.WriteLine("\npremi un tasto...");
                Console.ReadKey();
                eseguito = true;
            }
        }

        if (!eseguito)  //se non c'è il nome lo iserisco nel db.utenti
        {
            sql = $"INSERT INTO utenti (nome) VALUES ('{nome}');";
            command = new(sql, connection);
            command.ExecuteNonQuery();
        }

        //chiudo la connessione
        connection.Close();
        return nome;
    }

    /// <summary>
    /// Inizializza il frigorifero con degli alimenti, delle categorie, degli utenti e una lista spesa
    /// </summary>
    static void CreaFrigorifero()
    {
        SQLiteConnection connection = new($"Data Source=data/database.db; Version=3");
        connection.Open();

        string sql = @"
                    INSERT INTO utenti (nome) VALUES ('Luca'), ('Sara'), ('Alex'), ('Emy'); 
                    INSERT INTO listaSpesa (alimento, quantita, id_utente) VALUES ('yogurt', 3, 2),
                                                                                ('prosciutto cotto', 2, 1),
                                                                                ('maionese', 1, 3),
                                                                                ('insalata', 1, 1);
                    INSERT INTO categorie (nome) VALUES ('latticini'), ('carne'), ('pesce'), ('salumi'), ('verdure'), ('formaggi'), ('bevanda');
                    INSERT INTO alimenti (nome, quantita, data_inserimento, data_scadenza, id_categoria) VALUES ('pancetta', 2, '2024-02-10', '2024-02-15', 4),
                                                                                                                ('actimel', 6, '2024-02-15', '2024-03-13', 1),
                                                                                                                ('braciole', 5, '2024-02-21', '2024-02-28',2),
                                                                                                                ('ace', 1, '2024-01-21', '2024-01-25', 7),
                                                                                                                ('valeriana', 2, '2024-02-22', '2024-03-01', 5),
                                                                                                                ('salame', 4, '2024-02-03', '2024-03-11', 4),
                                                                                                                ('orata', 5, '2024-02-20', '2024-02-26', 3);
                    ";

        SQLiteCommand command = new(sql, connection);
        command.ExecuteNonQuery();

        connection.Close();

        Console.WriteLine("Inserimento avvenuto!");
        Thread.Sleep(800);
        Console.Clear();
    }
    #endregion

    #region METODI VISUALIZZA ALIMENTI

    /// <summary>
    /// Visualizza a schermo il risultato di una query sql.
    /// </summary>
    /// <param name="sql">La query che interroga il database</param>
    /// <param name="table">Oggetto di tipo table della classe Spectre.Console che contiene le etichette corrette</param>
    /// <param name="colonna">Il numero di colonne per la crazione della table</param>
    static void Stampa(string sql, Table table, int colonna)
    {
        SQLiteConnection connection = new($"Data Source=data/database.db; Version=3;");
        connection.Open();

        SQLiteCommand command = new(sql, connection);
        SQLiteDataReader reader = command.ExecuteReader();


        int riga = 0;
        while (reader.Read())
        {
            table.AddEmptyRow();
            for (int i = 0; i < colonna; i++)
            {
                table.UpdateCell(riga, i, $"{reader[i]}");
            }
            riga++;
        }

        AnsiConsole.Write(table);
        connection.Close();
    }

    /// <summary>
    /// Visualizza lista completa degli alimenti sotto forma di tabella
    /// </summary>
    static void VisualizzaAlimenti()
    {
        var table = new Table();
        table.AddColumns("id", "nome", "quantità", "categoria", "data_scadenza");

        string sql = "SELECT alimenti.id, alimenti.nome, alimenti.quantita, categorie.nome, DATE(alimenti.data_scadenza) FROM alimenti JOIN categorie ON alimenti.id_categoria = categorie.id;";
        Stampa(sql, table, 5);
    }

    /// <summary>
    /// Visualizza lista degli alimenti scaduti sotto forma di tabella
    /// </summary>
    static void VisualizzaScaduti()
    {
        var table = new Table();
        table.AddColumns("id", "nome", "quantità", "categoria", "data_scadenza");

        string sql = "SELECT alimenti.id, alimenti.nome, alimenti.quantita, categorie.nome , DATE(alimenti.data_scadenza)FROM alimenti JOIN categorie ON alimenti.id_categoria = categorie.id WHERE DATE(data_scadenza) < DATE('now');";
        Stampa(sql, table, 5);
    }

    /// <summary>
    /// Visualizza alimenti in esaurimento (quantita < 2) sotto forma di tabella
    /// </summary>
    static void VisualizzaInEsaurimento()
    {
        var table = new Table();
        table.AddColumns("id", "nome", "quantità", "categoria", "data_scadenza");

        string sql = "SELECT alimenti.id, alimenti.nome, alimenti.quantita, categorie.nome , DATE(alimenti.data_scadenza)FROM alimenti JOIN categorie ON alimenti.id_categoria = categorie.id WHERE quantita < 2;";
        Stampa(sql, table, 5);
    }

    /// <summary>
    /// Visualizza alimenti ordinati per nome
    /// </summary>
    static void VisualizzaPerNome()
    {
        var table = new Table();
        table.AddColumns("id", "nome", "quantità", "categoria", "data_scadenza");

        string sql = "SELECT alimenti.id, alimenti.nome, alimenti.quantita, categorie.nome , DATE(alimenti.data_scadenza)FROM alimenti JOIN categorie ON alimenti.id_categoria = categorie.id ORDER BY alimenti.nome;";
        Stampa(sql, table, 5);
    }

    /// <summary>
    /// Visualizza alimenti ordinati per data di scadenza
    /// </summary>
    static void VisualizzaPerDataScadenza()
    {
        var table = new Table();
        table.AddColumns("id", "nome", "quantità", "categoria", "data_scadenza");

        string sql = "SELECT alimenti.id, alimenti.nome, alimenti.quantita, categorie.nome , DATE(alimenti.data_scadenza)FROM alimenti JOIN categorie ON alimenti.id_categoria = categorie.id ORDER BY alimenti.data_scadenza;";
        Stampa(sql, table, 5);
    }

    /// <summary>
    /// Visualizza alimenti ordinati per data di inserimento
    /// </summary>
    static void VisualizzaPerDataInserimento()
    {
        var table = new Table();
        table.AddColumns("id", "nome", "quantità", "categoria", "data_scadenza");

        string sql = "SELECT alimenti.id, alimenti.nome, alimenti.quantita, categorie.nome , DATE(alimenti.data_scadenza)FROM alimenti JOIN categorie ON alimenti.id_categoria = categorie.id ORDER BY alimenti.data_inserimento;";
        Stampa(sql, table, 5);
    }

    /// <summary>
    /// Visualizza alimenti ordinati per categoria
    /// </summary>
    static void VisualizzaPerCategoria()
    {
        var table = new Table();
        table.AddColumns("id", "nome", "quantità", "categoria", "data_scadenza");

        string sql = "SELECT alimenti.id, alimenti.nome, alimenti.quantita, categorie.nome , DATE(alimenti.data_scadenza)FROM alimenti JOIN categorie ON alimenti.id_categoria = categorie.id ORDER BY categorie.nome;";
        Stampa(sql, table, 5);
    }

    #endregion

    #region METODI LISTA SPESA
    /// <summary>
    /// Visualizza la lista della spesa sotto forma di tabella
    /// </summary>
    static void VisualizzaListaSpesa()
    {
        var table = new Table();
        table.AddColumns("id", "alimento", "quantità", "nome_utente");

        string sql = "SELECT listaSpesa.id, listaSpesa.alimento, listaSpesa.quantita, utenti.nome FROM listaSpesa JOIN utenti ON listaSpesa.id_utente = utenti.id;";
        Stampa(sql, table, 4);
    }

    /// <summary>
    /// Inserisce un alimento nella lista della spesa, trova in automatico l'id_utente
    /// </summary>
    /// <param name="utente">Nome dell'utente attuale </param>
    static void InserisciAListaSpesa(string utente)
    {
        Console.WriteLine("Cosa vuoi aggiungere? ");
        string nome = Console.ReadLine()!;
        Console.WriteLine("Quanti ne inserisco? ");
        string quantita = Console.ReadLine()!;

        // Apro la connessione
        SQLiteConnection connection = new($"Data Source=data/database.db; Version=3;");
        connection.Open();

        string sql = $"INSERT INTO listaSpesa (alimento, quantita, id_utente) VALUES ('{nome}', {quantita}, (SELECT id FROM utenti WHERE nome = '{utente}'));";

        SQLiteCommand command = new(sql, connection);
        command.ExecuteNonQuery();
        //chiudo la connessione
        connection.Close();
    }

    static void ModificaListaSpesa()
    {
        Console.WriteLine("Quale alimento vuoi modificare?\n");
        VisualizzaListaSpesa();
        string idLista = Console.ReadLine()!;

        Console.WriteLine("Inserisci nuovo alimento");
        string alimento = Console.ReadLine()!;

        Console.WriteLine("Inserisci nuova quantita");
        string quantita = Console.ReadLine()!;

        Console.WriteLine("Nome di chi ha inserito il prodotto");
        string nomeUtente = Console.ReadLine()!;

        //apro la connessione
        SQLiteConnection connection = new($"Data Source=data/database.db; Version=3;");
        connection.Open();

        string sql = $"UPDATE listaSpesa SET alimento = '{alimento}', quantita = {quantita}, id_utente = (SELECT id FROM utenti WHERE nome = '{nomeUtente}') WHERE  id = {idLista};";

        SQLiteCommand command = new(sql, connection);
        command.ExecuteNonQuery();
        //chiudo la connessione
        connection.Close();
    }

    /// <summary>
    /// Permette di eliminare un record dalla tabella lista della spesa
    /// </summary>
    static void EliminaInListaSpesa()
    {
        Console.WriteLine("Quale alimento vuoi eliminare?\n");
        VisualizzaListaSpesa();

        string idLista = Console.ReadLine()!;

        //apro la connessione
        SQLiteConnection connection = new($"Data Source=data/database.db; Version=3;");
        connection.Open();

        string sql = $"DELETE FROM listaSpesa WHERE id = {idLista};";

        SQLiteCommand command = new(sql, connection);
        command.ExecuteNonQuery();

        //chiudo la connessione
        connection.Close();
    }
    #endregion

    #region METODI GESTIONE ALIMENTI
    static void InserisciAlimento()
    {
        Console.WriteLine("Cosa vuoi aggiungere? ");
        string nome = Console.ReadLine()!;
        Console.WriteLine("Quantità? ");
        string quantita = Console.ReadLine()!;
        Console.WriteLine("Data di scadenza YYYY-MM-DD: ");
        string dataScadenza = Console.ReadLine()!;
        Console.WriteLine("Categoria?");
        string categoria = Console.ReadLine()!;

        // Apro la connessione
        SQLiteConnection connection = new($"Data Source=data/database.db; Version=3;");
        connection.Open();

        string sql = $"INSERT INTO alimenti (nome, quantita, data_inserimento, data_scadenza, id_categoria) VALUES ('{nome}',{quantita}, DATE('now'), '{dataScadenza}', (SELECT id FROM categorie WHERE nome = '{categoria}'));";

        SQLiteCommand command = new(sql, connection);
        command.ExecuteNonQuery();
        //chiudo la connessione
        connection.Close();
    }

    /// <summary>
    /// Permette di modificare un alimento del frigo
    /// </summary>
    static void ModificaAlimento()
    {
        Console.WriteLine("Quale alimento vuoi modificare?\n");
        VisualizzaAlimenti();
        string idAlimento = Console.ReadLine()!;

        Console.WriteLine("Inserisci nuovo alimento");
        string nome = Console.ReadLine()!;

        Console.WriteLine("Inserisci nuova quantita");
        string quantita = Console.ReadLine()!;

        Console.WriteLine("Inserisci nuova data_scadenza YYYY-MM-DD");
        string dataScadenza = Console.ReadLine()!;

        Console.WriteLine("Inserisci categoria");
        string categoria = Console.ReadLine()!;

        //apro la connessione
        SQLiteConnection connection = new($"Data Source=data/database.db; Version=3;");
        connection.Open();

        string sql = $"UPDATE alimenti SET nome = '{nome}', quantita = {quantita}, data_inserimento = DATE('now'), data_scadenza = '{dataScadenza}', id_Categoria = (SELECT id FROM categorie WHERE nome = '{categoria}') WHERE id = {idAlimento};";

        SQLiteCommand command = new(sql, connection);
        command.ExecuteNonQuery();
        //chiudo la connessione
        connection.Close();
    }

    /// <summary>
    /// Permette di eliminare un alimento dalla tabella alimenti
    /// </summary>
    static void EliminaAlimento()
    {
        Console.WriteLine("Quale alimento vuoi eliminare?\n");
        VisualizzaAlimenti();

        string idAlimento = Console.ReadLine()!;

        //apro la connessione
        SQLiteConnection connection = new($"Data Source=data/database.db; Version=3;");
        connection.Open();

        string sql = $"DELETE FROM alimenti WHERE id = {idAlimento};";

        SQLiteCommand command = new(sql, connection);
        command.ExecuteNonQuery();

        //chiudo la connessione
        connection.Close();
    }
    #endregion

    #region METODI GESTIONE CATEGORIE
    /// <summary>
    /// Visualizza elenco categorie sotto forma di tabella
    /// </summary>
    static void VisualizzaCategorie()
    {
        var table = new Table();
        table.AddColumns("id", "categoria");

        string sql = "SELECT * FROM categorie;";
        Stampa(sql, table, 2);
    }

    /// <summary>
    /// Permette di modificare il nome di una categoria
    /// </summary>
    static void ModificaCategoria()
    {
        Console.WriteLine("Quale categoria vuoi modificare?\n");
        VisualizzaCategorie();
        string idCategoria = Console.ReadLine()!;

        Console.WriteLine("Inserisci nuovo nome categoria");
        string nome = Console.ReadLine()!;

        //apro la connessione
        SQLiteConnection connection = new($"Data Source=data/database.db; Version=3;");
        connection.Open();

        string sql = $"UPDATE categorie SET nome = '{nome}' WHERE id = {idCategoria};";

        SQLiteCommand command = new(sql, connection);
        command.ExecuteNonQuery();
        //chiudo la connessione
        connection.Close();
    }

    /// <summary>
    /// Permette di eliminare una categoria dalla tabella categorie
    /// </summary>
    static void EliminaCategoria()
    {
        Console.WriteLine("Quale categoria vuoi eliminare?\n");
        VisualizzaCategorie();

        string idCategoria = Console.ReadLine()!;

        //apro la connessione
        SQLiteConnection connection = new($"Data Source=data/database.db; Version=3;");
        connection.Open();

        string sql = $"DELETE FROM categorie WHERE id = {idCategoria};";

        SQLiteCommand command = new(sql, connection);
        command.ExecuteNonQuery();

        //chiudo la connessione
        connection.Close();
    }
    #endregion

    #region METODI GESTIONE UTENTI
    static void VisualizzaUtenti()
    {
        var table = new Table();
        table.AddColumns("id", "nome_utente");

        string sql = "SELECT * FROM utenti;";
        Stampa(sql, table, 2);
    }

    /// <summary>
    /// Permette di modificare il nome di un utente
    /// </summary>
    static void ModificaUtente()
    {
        Console.WriteLine("Quale utente vuoi modificare?\n");
        VisualizzaUtenti();
        string idUtente = Console.ReadLine()!;

        Console.WriteLine("Inserisci nuovo nome");
        string nome = Console.ReadLine()!;

        //apro la connessione
        SQLiteConnection connection = new($"Data Source=data/database.db; Version=3;");
        connection.Open();

        string sql = $"UPDATE utenti SET nome = '{nome}' WHERE id = {idUtente};";

        SQLiteCommand command = new(sql, connection);
        command.ExecuteNonQuery();
        //chiudo la connessione
        connection.Close();
    }

    static void EliminaUtente()
    {
        Console.WriteLine("Quale utente vuoi eliminare?\n");
        VisualizzaUtenti();

        string idUtente = Console.ReadLine()!;

        //apro la connessione
        SQLiteConnection connection = new($"Data Source=data/database.db; Version=3;");
        connection.Open();

        string sql = $"DELETE FROM utenti WHERE id = {idUtente};";

        SQLiteCommand command = new(sql, connection);
        command.ExecuteNonQuery();

        //chiudo la connessione
        connection.Close();
    }
    #endregion

}