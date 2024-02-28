public class ElencoPremi
{
    static Dictionary<int, string> premi = [];

    public static void InserisciPremi(int punteggio, string nomePremio)
    {
        premi.Add(punteggio, nomePremio);
    }
}