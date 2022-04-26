using System;
using OceniFilm.Models.Seznami;

namespace OceniFilm.Services
{
	public interface IPlaylistService
	{
		Task<IEnumerable<SeznamFilmov>> GetSeznamFilmovByUserAsync(string guid);
		Task<HttpResponseMessage> CreatePlaylistAsync(SeznamFilmov seznamFilmov);
        Task<HttpResponseMessage> EditPlaylistAsync(int id, SeznamFilmov seznamFilmov);
        Task<HttpResponseMessage> RemovePlaylistAsync(int id);
    }
}

