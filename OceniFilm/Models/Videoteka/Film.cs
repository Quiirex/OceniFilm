namespace OceniFilm.Models.Videoteka;

public class Film
{
    public int? Id { get; set; }
    public string Naslov { get; set; }
    public string Opis { get; set; }
    public int Dolzina { get; set; }
    public int ImdbOcena { get; set; }
    public string PGOcena { get; set; }
    public string Poster { get; set; }
    public int LetoIzdaje { get; set; }
    public string Napovednik { get; set; }
    public List<Zanr> SeznamZanrov { get; set; }
    public Reziser Reziser { get; set; }
    public List<IgralecFilma> SeznamIgralcev { get; set; }
}