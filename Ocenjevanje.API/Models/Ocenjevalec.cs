using System.ComponentModel.DataAnnotations;

namespace Ocenjevanje.API.Models;

public class Ocenjevalec
{
    [Key][Required] public int Id { get; set; }

    public string UporabniskoIme { get; set; } = string.Empty;
}