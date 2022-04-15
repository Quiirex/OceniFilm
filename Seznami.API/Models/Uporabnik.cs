using System.ComponentModel.DataAnnotations;

namespace Seznami.API.Models;

public class Uporabnik
{
    [Key] [Required] public int Id { get; set; }

    public string UporabniskoIme { get; set; }
}