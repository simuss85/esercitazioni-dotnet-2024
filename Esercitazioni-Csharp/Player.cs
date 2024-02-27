class Player
{
    private string? codiceID;
    private string? nome;
    private string? colore;
    private List<string> territori;

    //costruttore
    public Player() { }
    public Player(string codiceID, string nome, string colore)
    {
        this.codiceID = codiceID;
        this.nome = nome;
        this.colore = colore;
    }

    //getter e setter
    public string ID { get => codiceID!; set => codiceID = value; }
    public string Nome { get => nome!; set => nome = value; }
    public string Colore { get => colore!; set => colore = value; }
    public List<string> Territori { get => territori!; set => territori = value; }

    /// <summary>
    /// Inizializza il giocatore a partire dalla stringa ottenuta dal file csv
    /// </summary>
    /// <param name="arrayCSV">La stringa ottenunta dal file save.csv</param>
    public void Carica(string[] arrayCSV)
    {
        codiceID = arrayCSV[0];
        nome = arrayCSV[1];
        colore = arrayCSV[2];

        for (int i = 3; i < arrayCSV.Length; i++)
        {
            if (arrayCSV[i] != "_")
            {
                territori.Add(arrayCSV[i]);
            }
        }
    }

    /// <summary>
    /// Stampa del giocatore a schermo
    /// </summary>
    public void Stampa()
    {
        Console.WriteLine($"Codice ID: {ID}");
        Console.WriteLine($"Nome: {nome}");
        Console.WriteLine($"Armate: {colore}");
        Console.Write("Lista territori attuale: ");
        Console.WriteLine(territori.Count);
        if (territori.Count != 0)
        {
            foreach (string territorio in territori)
            {
                Console.Write(territorio + " ");
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Nessuno!!!");
        }

    }

}