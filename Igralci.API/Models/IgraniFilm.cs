using System.ComponentModel.DataAnnotations;

namespace Igralci.API.Models;

public class IgraniFilm
{
    [Key][Required] public int Id { get; set; }

    public string Naslov { get; set; } = string.Empty;
}