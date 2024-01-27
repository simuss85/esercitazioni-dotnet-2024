class Test
{
    static void Main(string[] args)
    {
        Dictionary<string, string> nomi = [];
        nomi.Add("Ussi", "Simone");
        nomi.Add("Xxxx", "Fabio");
        nomi.Add("Gigante", "Emanuela");

        foreach (string cognome in nomi.Keys)
        {   
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Write(cognome);
            Console.ResetColor();
            Console.WriteLine(" - colore ripristinato!");
        }
    }
}