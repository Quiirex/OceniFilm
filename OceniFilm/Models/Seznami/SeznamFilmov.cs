namespace OceniFilm.Models.Seznami;

public class SeznamFilmov
{
    // public int? Id { get; set; }
    public Uporabnik? Uporabnik { get; set; }
    public string? NazivSeznama { get; set; }
    public List<Film>? Filmi { get; set; }
}