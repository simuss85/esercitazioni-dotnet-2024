
namespace FotoGalleryMvcId.Models;

public class IndexViewModel
{
    public int NumeroPagine { get; set; }
    public string? Categoria { get; set; }
    public int? PageIndex { get; set; }
    public IEnumerable<Immagine>? Immagini { get; set; }
    public List<string>? Categorie { get; set; }
    public string jsonPath = @"wwwroot/json/immagini.json";
    public string jsonPath3 = @"wwwroot/json/categorie.json";
}