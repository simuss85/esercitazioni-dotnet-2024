class Program
{
    static void Main(string[] args)
    {   
        //TEST DEI MENU DI GIOCO
        Console.Clear();
        CreaMenuSelezionePrincipale();
        Console.ReadKey();
        
        Console.Clear();
        MenuSelezioneColoreUtente();
        Console.ReadKey();
        
        Console.Clear();
        MenuDiGioco();
        Console.ReadKey();
        
        Console.Clear();
        DisegnaMappa();
        Console.ReadKey();
        

        


    }

    static void CreaMenuSelezionePrincipale()
    {
        Console.WriteLine("1. Gioca contro il pc");
        Console.WriteLine("2. Gioca contro altro utente");
        Console.WriteLine("3. Carica ultima partita");
        Console.WriteLine("4. Regole del gioco");
        Console.WriteLine("5. Esci");
    }

    static void MenuSelezioneColoreUtente()
    {
        Console.WriteLine("r. Rosso");
        Console.WriteLine("b. Blu");
        Console.WriteLine("n. Nero");
        Console.WriteLine("g. Giallo");
        Console.WriteLine("v. Verde");
    }

    static void MenuDiGioco()
    {
        Console.WriteLine("1. Lancia i dadi");
        Console.WriteLine("2. Scommetti su pari o dispari");
        Console.WriteLine("3. Scommetti sul numero esatto");
        Console.WriteLine("s. Salva il gioco ed esci");
        Console.WriteLine("'ctrl'+'M' Visualizza mappa");
    }

    static void DisegnaMappa()
    {
        Console.WriteLine("\tMappa del mondo");
        Console.WriteLine("|AMERICA|EUROPA|ASIA|POLO NORD|");
        Console.WriteLine("|SUD AMERICA|AFRICA|OCEANIA|POLO SUD|");
    }

}