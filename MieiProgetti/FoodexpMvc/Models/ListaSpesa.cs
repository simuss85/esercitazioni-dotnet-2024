namespace FoodexpMvc.Models
{
    public class ListaSpesa
    {
        public int Id { get; set; }
        public string? Alimento { get; set; }
        public int Quantita { get; set; }
        //chiavi estene
        public int CategoriaId { get; set; }
        public List<Categoria>? Categorie { get; set; } //riferimento molti a uno utenti
        public int UtenteId { get; set; }
        public List<Utente>? Utenti { get; set; }   //riferimento molti a uno categorie
    }
}