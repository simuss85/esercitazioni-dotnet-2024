namespace FoodexpMvc.Models
{
    public class Alimento
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int Quantita { get; set; }
        public DateTime DataScadenza { get; set; }
        public DateTime DataInserimento { get; set; }
        public Categoria? Categoria { get; set; }
        public string? Info { get; set; }
    }
}