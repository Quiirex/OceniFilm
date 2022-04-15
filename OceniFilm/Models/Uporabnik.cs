namespace OceniFilm.Models;

public class Uporabnik
{
    public string? Id { get; set; }
    public string? Ime { get; set; }
    public string? Priimek { get; set; }
    public string? PrikaznoIme { get; set; }
    public string? Email { get; set; }
    public string? Geslo { get; set; }
    public string? Sol { get; set; }
    public DateTime? DatumRojstva { get; set; }
}