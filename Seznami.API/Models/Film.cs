using System.ComponentModel.DataAnnotations;

namespace Seznami.API.Models;

public class Film
{
    [Key][Required] public int Id { get; set; }

    public string Naslov { get; set; }
}