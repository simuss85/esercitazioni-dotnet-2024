
public class Game
{
    public void Gioca()
    {
        GestisciTxt.CreaTxt();

        Console.WriteLine("Inserisci il tuo nome");
        string nome = Console.ReadLine()!;

        Player p = new(nome);

        GestisciTxt.InizializzaTxt(p);

    }

    //avvia il gioco

    //menu selezione difficolta

    //selezione difficilta

    //menu selezione aiuti

    //selezione aiuti

    //avvio turno

    //inserimento numero giocatore

    //controllo numero

    //verifica vincita

    //continui o esci

    //risultato e premio
}