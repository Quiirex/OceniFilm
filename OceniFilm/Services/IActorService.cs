using System;
using OceniFilm.Models.Igralci;

namespace OceniFilm.Services
{
	public interface IActorService
	{
		Task<Igralec> GetActorInfoAsync(string ime, string priimek);
	}
}

