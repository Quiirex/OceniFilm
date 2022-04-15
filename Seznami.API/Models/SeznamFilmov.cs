using System.ComponentModel.DataAnnotations;

namespace Seznami.API.Models;

public class SeznamFilmov
{
    [Key] [Required] public int Id { get; set; }

    public Uporabnik Uporabnik { get; set; }
    public string NazivSeznama { get; set; }
    public List<Film> Filmi { get; set; }
}