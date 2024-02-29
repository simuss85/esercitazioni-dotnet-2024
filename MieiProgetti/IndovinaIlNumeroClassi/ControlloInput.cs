/// <summary>
/// Verifica l'input inserito dall'utente nei casi generali stringa o numerico.
/// </summary>
public class ControlloInput
{
    private bool valido;

    //costruttore
    public ControlloInput()
    {
        this.valido = false;
    }

    //getter e setter
    public bool Valido { get => valido; set => valido = value; }

    /// <summary>
    /// Controlla se l'utente digita un valore corretto di tipo stringa. <br/>
    /// - verifica stringa vuota <br/>
    /// - verifica numero inserito qundi errato
    /// </summary>
    /// <param name="input">L'input inserito dall'utente</param>
    public virtual void Stringa(string input)
    {
        valido = false;

        if (input == "")
        {
            Console.WriteLine("Nessun input inserito");
            PremiUnTasto();
        }
        else if (int.TryParse(input, out _))
        {
            Console.WriteLine("Hai inserito un numero");
            PremiUnTasto();
        }
        else
        {
            valido = true;
        }
    }

    /// <summary>
    /// Controlla se l'utente digita un valore corretto di tipo numerico. <br/>
    /// - verifica stringa vuota <br/>
    /// - verifica stringa inserita qundi errata
    /// </summary>
    /// <param name="input">L'input inserito dall'utente</param>
    public virtual void Numero(string input)
    {
        valido = false;

        if (input == "")
        {
            Console.WriteLine("Nessun input inserito");
            PremiUnTasto();
        }
        else if (!int.TryParse(input, out _))
        {
            Console.WriteLine("Devi inserire un numero");
            PremiUnTasto();
        }
        else
        {
            valido = true;
        }
    }

    /// <summary>
    /// Metodo accessorio che permette la lettura dell'output all'utente fino a quando non <br/>
    /// viene premuto un tasto da tastiera.
    /// </summary>
    /// <param name="messaggio">Messaggio opzionale da inserire dopo l'errore</param>
    public void PremiUnTasto(string messaggio = "")
    {
        Console.WriteLine(messaggio);
        Console.WriteLine("premi un tasto...");
        Console.ReadKey();
    }

}