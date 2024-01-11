class Program
{
    static void Main(string[] args)
    {   
        // utilizziamo il diamond invece di parentesi quadre
        Queue<string> nomi = new Queue<string>();
        nomi.Enqueue("Mario"); // aggiungo elemento con metodo Enqueue
        nomi.Enqueue("Luigi");
        nomi.Enqueue("Giovanni");
        
        System.Console.WriteLine($"Ciao {nomi.Dequeue()}, {nomi.Dequeue()} e {nomi.Dequeue}");
        
    }
}