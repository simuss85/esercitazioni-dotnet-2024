public class GestisciTxt
{
    private static string path = @"giocatori.txt";
    public static void CreaTxt()
    {
        if (!File.Exists(path))
        {
            File.Create(path).Close();
            File.AppendAllText(path, "Punteggi giocatori!\n\n");
        }
    }

    public static void InizializzaTxt(Player p)
    {
        string[] listaGiocatori = File.ReadAllLines(path);


        //verifico se è un nuovo giocatore oppure no
        if (!listaGiocatori.Any(linea => linea.StartsWith(p.Nome)))
        {   //se non è presente...
            StampaSuTxt(p);
        }
        else    //se è presente il giocatore, memorizzo i suoi dati
        {
            for (int i = 0; i < listaGiocatori.Length; i++)
            {
                if (listaGiocatori[i].StartsWith(p.Nome))
                {
                    p.Punteggio = double.Parse(listaGiocatori[i + 1].Substring(11));
                }
            }
        }
    }

    /// <summary>
    /// Salva i dati della partita attuale nel file path
    /// </summary>
    /// <param name="p">Oggetto Player da salvare nel file</param>
    public static void Salva(Player p)
    {
        // salvataggio sul file del punteggio
        string[] listaGiocatori = File.ReadAllLines(path);    // copio il file aggiornato nell'array del file aggiornato

        for (int i = 0; i < listaGiocatori.Length; i++)
        {
            if (listaGiocatori[i].StartsWith(p.Nome))
            {
                listaGiocatori[i + 1] = $"Punteggio: {p.Punteggio}";  // modifico il punteggio
            }
        }
        File.WriteAllLines(path, listaGiocatori);   //ripristino il file con i dati aggiornati
    }

    /// <summary>
    /// Scrive su file path Il nome del giocatore e il punteggio formattato
    /// </summary>
    /// <param name="p">Oggetto Player da scrivere su file</param>
    private static void StampaSuTxt(Player p)
    {
        string punteggioGiocatore = $"Punteggio: {p.Punteggio}";
        //stampa nel file la prima riga di asterischi
        StampaAsterischi();
        //stampa nel file il nome del giocatore
        File.AppendAllText(path, p.Nome);
        for (int i = 0; i < (18 - p.Nome.Length); i++)
        {
            if (i == (17 - p.Nome.Length))
            {
                File.AppendAllText(path, "\n");          //chiusura del box di * (dava problemi!!!)
                break;
            }
            else
            {
                File.AppendAllText(path, " ");              //inserisce gli spazi dopo il nome
            }
        }
        //stampa nel file il punteggio del giocatore
        File.AppendAllText(path, punteggioGiocatore);
        for (int i = 0; i < (18 - punteggioGiocatore.Length); i++)
        {
            if (i == (17 - punteggioGiocatore.Length))
            {
                File.AppendAllText(path, "\n");          //chiusura del box di * (dava problemi!!!)
            }
            else
            {
                File.AppendAllText(path, " ");              //inserisce gli spazi dopo il nome
            }
        }
        StampaAsterischi();

    }

    /// <summary>
    /// Metodo accessorio che stampa una riga di 18 asterischi nel file path
    /// </summary>
    private static void StampaAsterischi()
    {
        for (int i = 0; i < 18; i++)
        {
            if (i == 17)
            {
                File.AppendAllText(path, "*\n");
            }
            else
            {
                File.AppendAllText(path, "*");
            }
        }
    }

}