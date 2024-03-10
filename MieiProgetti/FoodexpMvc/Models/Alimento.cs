namespace FoodexpMvc.Models
{
    public class Alimento
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int Quantita { get; set; }
        public Date? DataScadenza { get; set; }
        public Date? DataInserimento { get; set; }
        //chiave esterna
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; } //riferimento molti a uno tab-categoria
        public string? Info { get; set; }
    }
}