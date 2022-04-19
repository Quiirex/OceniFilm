using System.ComponentModel.DataAnnotations;

namespace Komentiranje.API.Models;

public class Komentator
{
    [Key][Required] public int Id { get; set; }

    public string UporabniskoIme { get; set; } = string.Empty;
}