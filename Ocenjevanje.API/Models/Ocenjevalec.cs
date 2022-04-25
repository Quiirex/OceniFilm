using System.ComponentModel.DataAnnotations;

namespace Ocenjevanje.API.Models;

public class Ocenjevalec
{
    [Key][Required] public int Id { get; set; }

    public string Guid { get; set; } = string.Empty;
}