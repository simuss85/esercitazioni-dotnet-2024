namespace FotoGalleryMvcId.Models;

public class Log
{
    public int Id { get; set; }
    public DateTime? DataOperazione { get; set; }
    public string? Alias { get; set; }
    public string? Email { get; set; }
    public string? Ruoli { get; set; }
    public string? OperazioneSvolta { get; set; }
    public bool Tipologia { get; set; }    //indica se l'operazione è di tipo userExperience (true), amministrativa (false)
}