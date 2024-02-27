class Persona
{
    private string? nome;
    private string? cognome;
    private int eta;

    //costruttore
    public Persona(string nome, string cognome, int eta)
    {
        this.Nome = nome;
        this.Cognome = cognome;
        this.Eta = eta;
    }

    //getter e setter
    public string Nome { get => nome!; set => nome = value; }
    public string Cognome { get => cognome!; set => cognome = value; }
    public int Eta { get => eta; set => eta = value; }

    //metodi di classe
    public void Stampa()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Cognome: {Cognome}");
        Console.WriteLine($"Eta: {Eta}");
    }
}