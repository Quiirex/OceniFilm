namespace OceniFilm.Models.Igralci;

public class Igralec
{
    // public int? Id { get; set; }
    public string? Ime { get; set; }
    public string? Priimek { get; set; }
    public DateTime? DatumRojstva { get; set; }
    public string? Biografija { get; set; }
    public string? Fotografija { get; set; }
    public List<IgraniFilm>? SeznamFilmov { get; set; }
}