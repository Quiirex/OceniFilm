using System.ComponentModel.DataAnnotations;

namespace Komentiranje.API.Models;

public class Komentator
{
    [Key][Required] public int Id { get; set; }

    public string Guid { get; set; } = string.Empty;
}