using System.ComponentModel.DataAnnotations;

namespace Komentiranje.API.Models
{
    public class KomentiranFilm
    {
        [Key][Required] public int Id { get; set; }

        public string Naslov { get; set; } = string.Empty;
    }
}
