using System;
using OceniFilm.Models.Komentiranje;

namespace OceniFilm.Services
{
	public interface ICommentService
	{
		Task<IEnumerable<Komentar>> GetCommentsByFilmAsync(string naslovFilma);
	}
}

