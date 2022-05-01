using System;
using OceniFilm.Models.Ocenjevanje;

namespace OceniFilm.Services
{
	public interface IRatingService
	{
		Task<Ocena> GetOcenaByTitleAndUserAsync(string naslovFilma, string prikaznoIme);
		Task<HttpResponseMessage> CreateRatingAsync(Ocena ocena);
		Task<HttpResponseMessage> EditRatingAsync(int id, Ocena ocena);
		Task<HttpResponseMessage> RemoveRatingAsync(int id);
    }
}

