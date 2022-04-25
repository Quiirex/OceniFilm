using OceniFilm.Models.Videoteka;

namespace OceniFilm.Services
{
    public interface IFilmService
    {
        Task<IEnumerable<Film>> GetFilmiAsync();
        Task<Film> GetFilmByTitleAsync(string naslovFilma);
    }
}
