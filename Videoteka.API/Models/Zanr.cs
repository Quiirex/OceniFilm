using System.ComponentModel.DataAnnotations;

namespace Videoteka.API.Models
{
    public class Zanr
    {
        [Key][Required] public int Id { get; set; }

        public string Naziv { get; set; }
    }
}
