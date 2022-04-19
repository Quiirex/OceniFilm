using System.ComponentModel.DataAnnotations;

namespace Ocenjevanje.API.Models;

public class Ocena
{
    [Key][Required] public int Id { get; set; }

    public int Vrednost { get; set; }
    public DateTime DatumOcene { get; set; }
    public Ocenjevalec Ocenjevalec { get; set; }
    public OcenjenFilm OcenjenFilm { get; set; }
}