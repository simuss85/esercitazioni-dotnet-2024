class Program
{
    static void Main(string[] args)
    {
        string nome = "Mario";
        string cognome = "Rossi";
        bool diversi = (nome != cognome);
        System.Console.WriteLine($"I due nomi sono uguali? {diversi}");
    }
}