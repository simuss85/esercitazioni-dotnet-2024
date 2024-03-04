public class Ordine
{
    public int Id { get; set; }
    public int ProdottoId { get; set; }
    public Prodotto? Prodotto { get; set; }  //relazione con tabella prodotto
}