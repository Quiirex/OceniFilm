using System.ComponentModel.DataAnnotations;

namespace Identiteta.API.Models;

public class Uporabnik
{
    [Key][Required] public string Id { get; set; }
    public string Ime { get; set; } = string.Empty;
    public string Priimek { get; set; } = string.Empty;
    public string PrikaznoIme { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Geslo { get; set; } = string.Empty;
    public string Sol { get; set; } = string.Empty;
    public DateTime DatumRojstva { get; set; }
}