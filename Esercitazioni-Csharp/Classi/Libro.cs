class Libro
{
    private string titolo;
    private string autore;

    public Libro(string titolo, string autore)
    {
        this.titolo = titolo;
        this.autore = autore;
    }

    public string Titolo { get => titolo; set => titolo = value; }
    public string Autore { get => autore; set => autore = value; }

    public void Stampa()
    {
        Console.WriteLine($"Titolo: {titolo}");
        Console.WriteLine($"Autore: {autore}");
    }
}