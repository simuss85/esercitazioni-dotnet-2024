public class Cliente
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Cognome { get; set; }
    public string? Telefono { get; set; }
    public List<Prodotto>? Prodotti { get; set; }   //relazione uno a molti con tabella prodotti
}