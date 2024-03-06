namespace FoodexpMvc.Models
{
    public class ListaSpesa
    {
        public int Id { get; set; }
        public string? Alimento { get; set; }
        public int Quantita { get; set; }
        public List<Utente>? Utenti { get; set; }
        public List<Categoria>? Categorie { get; set; }

    }
}