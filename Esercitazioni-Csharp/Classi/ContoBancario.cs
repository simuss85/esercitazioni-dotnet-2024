class ContoBancario
{
    private string? nome;
    private double saldo;

    public ContoBancario(string nome, double saldo)
    {
        this.nome = nome;
        this.saldo = saldo;
    }

    public string? Nome { get => nome; set => nome = value; }
    public double Saldo { get => saldo; set => saldo = value; }

    /*
    public string Nome 
    {
        get { return nome; }
        set { nome = value; }
    }

    public double Saldo
    {
        get { return saldo; }
        set { saldo = value; }
    }
    */

    public void Deposita(double importo)
    {
        saldo += importo;
    }

    public void Preleva(double importo)
    {
        saldo -= importo;
    }

    public void Stampa()
    {
        Console.WriteLine($"Nome: {nome}");
        Console.WriteLine($"Saldo: {saldo}");
    }
}