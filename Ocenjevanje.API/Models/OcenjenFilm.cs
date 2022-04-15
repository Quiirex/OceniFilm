using System.ComponentModel.DataAnnotations;

namespace Ocenjevanje.API.Models;

public class OcenjenFilm
{
    [Key] [Required] public int Id { get; set; }

    public string Naslov { get; set; }
}