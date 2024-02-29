public class Prodotto
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public double Prezzo { get; set; }
    public int ClienteId { get; set; }
    public Cliente? Cliente { get; set; }    //relazione con la tabella cienti
}