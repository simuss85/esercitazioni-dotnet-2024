class Program
{
    static void Main(string[] args)
    {
        Persona p = new();
        p.nome = "Mario";
        p.cognome = "Rossi";
        p.eta = 30;

        Console.WriteLine($"Nome: {p.nome}");
        Console.WriteLine($"Cognome: {p.cognome}");
        Console.WriteLine($"Eta: {p.eta}");
    }
}