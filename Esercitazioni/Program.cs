class Program
{
    static void Main(string[] args)
    {
        string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.csv");

        foreach (string file in files)
        {
            Console.WriteLine(Path.GetFileName(file));    //stampa i nomi dei file presenti nella cartella attuale
        }
        Console.WriteLine("Vuoi leggere o eliminare un file? (l/e)");
        string risposta = Console.ReadLine()!;
        if (risposta == "l")
        {
            Console.WriteLine("Quale file vuoi leggere?");
            string fileSelezionato = Console.ReadLine()!;
            try
            {
                string[] righe =  File.ReadAllLines(fileSelezionato);
                foreach (string riga in righe)
                {
                    Console.WriteLine(riga);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Il file selezionato non esiste");
            }
        }
        else if (risposta == "e")
        {
            Console.WriteLine("Quale file vuoi eliminare?");
            string fileSelezionato = Console.ReadLine()!;
            try
            {
                File.Delete(fileSelezionato);
                Console.WriteLine("File eliminato");
            }
            catch (Exception)
            {
                Console.WriteLine("Il file non esiste");
            }
        }          
    }
}