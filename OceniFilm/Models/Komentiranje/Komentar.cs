namespace OceniFilm.Models.Komentiranje;

public class Komentar
{
    public int? Id { get; set; }
    public string? Vsebina { get; set; }
    public DateTime? DatumZapisa { get; set; }
    public Komentator? Komentator { get; set; }
}