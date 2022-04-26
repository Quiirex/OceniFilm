using System;
using OceniFilm.Models.Seznami;

namespace OceniFilm.Services
{
	public interface IPlaylistService
	{
		Task<IEnumerable<SeznamFilmov>> GetSeznamFilmovByUserAsync(string guid);
	}
}

