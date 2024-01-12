class Program
{
    static void Main(string[] args)
    {
        string[] nomi = new string[3];
        nomi[0] = "Mario";
        nomi[1] = "Luigi";
        nomi[2] = "Giovanni";

        foreach (string nome in nomi)
        {
            System.Console.WriteLine($"Ciao {nome}");
        }
        
    }
}