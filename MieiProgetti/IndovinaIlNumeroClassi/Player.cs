public class Player
{
    private string nome;
    private double punteggio;
    private int tentativi;
    private string saluto;

    //getter e setter
    public string Nome { get => nome; }
    public double Punteggio { get => punteggio; set => punteggio = value; }
    public int Tentativi { get => tentativi; set => tentativi = value; }
    public string Saluto { get => saluto; set => saluto = value; }

    //costruttore
    public Player(string nome)
    {
        this.nome = nome;
        this.punteggio = 0;
        this.tentativi = 0;
        this.saluto = "Benvenuto ";
    }
}