using OceniFilm.Models.Seznami;

namespace OceniFilm.Services
{
    public interface IPlaylistService
    {
        Task<IEnumerable<SeznamFilmov>> GetSeznamFilmovByUserAsync(string prikaznoIme);
        Task<HttpResponseMessage> CreatePlaylistAsync(SeznamFilmov seznamFilmov);
        Task<HttpResponseMessage> AddToPlaylistAsync(string prikaznoIme, string nazivSeznama, Film film);
        Task<HttpResponseMessage> RemoveFromPlaylistAsync(string prikaznoIme, string nazivSeznama, Film film);
        Task<HttpResponseMessage> RemovePlaylistAsync(SeznamFilmov seznamFilmov);
    }
}

