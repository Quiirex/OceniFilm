using System.ComponentModel.DataAnnotations;

namespace OceniFilm.Models;

public class RegistracijaUporabnika
{
    [Display(Name = "Ime")]
    [Required(ErrorMessage = "Polje je obvezno")]
    [StringLength(100, ErrorMessage = "Ime ne sme biti krajše od 2 znakov", MinimumLength = 2)]
    [RegularExpression(@"^[a-zA-Z_\u00A1-\uFFFF\s]{0,100}$", ErrorMessage = "Dovoljene so samo črke")]
    public string? Ime { get; set; }

    [Display(Name = "Priimek")]
    [Required(ErrorMessage = "Polje je obvezno")]
    [StringLength(100, ErrorMessage = "Priimek ne sme biti krajši od 2 znakov", MinimumLength = 2)]
    [RegularExpression(@"^[a-zA-Z_\u00A1-\uFFFF\s]{0,100}$", ErrorMessage = "Dovoljene so samo črke")]
    public string? Priimek { get; set; }

    [Display(Name = "Prikazno ime")]
    [Required(ErrorMessage = "Polje je obvezno")]
    [StringLength(15, ErrorMessage = "Prikazno ime ne sme biti krajše od 2 znakov in daljše od 15 znakov",
        MinimumLength = 2)]
    [RegularExpression(@"^[a-zA-Z0-9_.-]*$", ErrorMessage = "Dovoljene so samo črke in števila")]
    public string? PrikaznoIme { get; set; }

    [Display(Name = "Email")]
    [EmailAddress(ErrorMessage = "Email naslov ni veljaven")]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Polje je obvezno")]
    public string? Email { get; set; }

    [Display(Name = "Geslo")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Polje je obvezno")]
    [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{15,}$",
        ErrorMessage = "Geslo mora vsebovati vsaj 15 črk, 1 poseben znak in vsaj 1 številko")]
    public string? Geslo { get; set; }

    [Display(Name = "Potrdi geslo")]
    [DataType(DataType.Password)]
    [Compare("Geslo", ErrorMessage = "Gesli se ne ujemata!")]
    [Required(ErrorMessage = "Polje je obvezno")]
    public string? GesloPonovno { get; set; }

    [Display(Name = "Datum rojstva")]
    [Required(ErrorMessage = "Polje je obvezno")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? DatumRojstva { get; set; }
}