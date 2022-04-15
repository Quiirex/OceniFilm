using System.ComponentModel.DataAnnotations;

namespace OceniFilm.Models;

public class PrijavaUporabnika
{
    [EmailAddress(ErrorMessage = "Email naslov ni veljaven")]
    [Display(Name = "Email")]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "To polje je obvezno")]
    public string? Email { get; set; }


    [Display(Name = "Geslo")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "To polje je obvezno")]
    public string? Geslo { get; set; }
}