using System;
using OceniFilm.Models.Seznami;

namespace OceniFilm.Services
{
	public interface IPlaylistService
	{
		Task<IEnumerable<SeznamFilmov>> GetSeznamFilmovByUserAsync(string prikaznoIme);
		Task<HttpResponseMessage> CreatePlaylistAsync(SeznamFilmov seznamFilmov);
        Task<HttpResponseMessage> EditPlaylistAsync(SeznamFilmov seznamFilmov);
        Task<HttpResponseMessage> RemovePlaylistAsync(SeznamFilmov seznamFilmov);
    }
}

