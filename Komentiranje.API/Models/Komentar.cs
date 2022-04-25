using System.ComponentModel.DataAnnotations;

namespace Komentiranje.API.Models;

public class Komentar
{
    [Key][Required] public int Id { get; set; }

    public string Vsebina { get; set; } = string.Empty;
    public DateTime DatumZapisa { get; set; }
    public KomentiranFilm KomentiranFilm { get; set; }
    public Komentator Komentator { get; set; }
}