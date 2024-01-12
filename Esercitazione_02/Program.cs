class Program
{
    static void Main(string[] args)
    {
        string[] nomi = new string[5];
        nomi[0] = "Luigi";
        nomi[1] = "Mario";
        nomi[2] = "Luca";
        nomi[3] = "Mario";
        nomi[4] = "Mario";

        List<string> lista = new List<string>();

        foreach (string nome in nomi)
        {
            if (nome == "Mario")
            {
                System.Console.WriteLine("Trovato!");
                lista.Add(nome);
            }
        }

        System.Console.WriteLine($"La lista contiene {lista.Count} elementi");

    }
}