    class Program
    {
        // programma per le prove 
        static void Main(string[] args)
        {
            List<int> list = [1,2,3];

            Console.WriteLine($"{string.Join(", ", list)}");
            list = list.Distinct().ToList();
            
            List<string> nomi = ["a", "bi", "ciao"];            
        }
    }
