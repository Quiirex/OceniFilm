using System;
using OceniFilm.Models.Ocenjevanje;

namespace OceniFilm.Services
{
	public interface IRatingService
	{
		Task<Ocena> GetOcenaByTitleAndUserAsync(string naslovFilma, string guid);
	}
}

