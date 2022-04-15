using System.ComponentModel.DataAnnotations;

namespace Igralci.API.Models;

public class Igralec
{
    [Key] [Required] public int Id { get; set; }

    public string Ime { get; set; } = string.Empty;
    public string Priimek { get; set; } = string.Empty;
    public DateTime? DatumRojstva { get; set; }
    public string Biografija { get; set; } = string.Empty;
    public string Fotografija { get; set; } = string.Empty;
    public List<IgraniFilm>? SeznamFilmov { get; set; }
}