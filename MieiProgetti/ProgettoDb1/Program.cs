using System.Data.SQLite;

class Program
{
    static void Main(string[] args)
    {
        string path = @"database.db";
        if (!File.Exists(path)) //se non esiste il db lo devo creare
        {
            SQLiteConnection.CreateFile(path);
            SQLiteConnection connection = new($"Data Source={path}; Version=3;"); //creo la connessione al db
            connection.Open(); //apre la connessione

            string sql = @"
                            CREATE TABLE prodotti (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE, prezzo REAL, quantita INTEGER CHECK (quantita >= 0));
                            INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('p1', 1, 10), 
                                                                                 ('p2', 2, 20), 
                                                                                 ('p3', 3, 30);
                            ";
            SQLiteCommand command = new(sql, connection);  //prepara il comando sql
            command.ExecuteNonQuery();  //esegue il comando
            connection.Close(); //chiudi la connessione
        }

        while (true)
        {
            Console.WriteLine("1 - inserisci prodotto");
            Console.WriteLine("2 - visualizza prodotti");
            Console.WriteLine("3 - elimina prodotto");
            Console.WriteLine("4 - esci");
            Console.WriteLine("scegli un'opzione");
            string scelta = Console.ReadLine()!;
            switch (scelta)
            {
                case "1":
                    InserisciProdotto();
                    break;

                case "2":
                    VisualizzaProdotto();
                    break;

                case "3":
                    EliminaProdotto();
                    break;

                case "4":
                    return;

                default:
                    Console.WriteLine("Errore");
                    break;
            }
        }

    }

    static void InserisciProdotto()
    {
        Console.WriteLine("inserisci il nome del prodotto");
        string nome = Console.ReadLine()!;
        Console.WriteLine("inserisci il prezzo del prodotto");
        string prezzo = Console.ReadLine()!;
        Console.WriteLine("inserisci la quantità del prodotto");
        string quantita = Console.ReadLine()!;

        SQLiteConnection connection = new($"Data Source=database.db; Version=3;");
        connection.Open();
        string sql = $"INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('{nome}', {prezzo}, {quantita});";
        SQLiteCommand command = new(sql, connection);
        command.ExecuteNonQuery();
        connection.Close();
    }

    static void VisualizzaProdotto()
    {
        SQLiteConnection connection = new($"Data Source=database.db; Version=3;");
        connection.Open();
        string sql = $"SELECT * FROM prodotti;";
        SQLiteCommand command = new(sql, connection);
        SQLiteDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, prezzo: {reader["prezzo"]}, quantita: {reader["quantita"]}");
        }
        connection.Close();
    }

    static void EliminaProdotto()
    {
        Console.WriteLine("inserisci il nome del prodotto da eliminare");
        string nome = Console.ReadLine()!;
        SQLiteConnection connection = new($"Data Source=database.db; Version=3;");
        connection.Open();
        string sql = $"DELETE FROM prodotti WHERE nome = '{nome}';";
        SQLiteCommand command = new(sql, connection);
        command.ExecuteNonQuery();
        connection.Close();
    }
}