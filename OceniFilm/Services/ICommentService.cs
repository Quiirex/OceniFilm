using OceniFilm.Models.Komentiranje;

namespace OceniFilm.Services
{
    public interface ICommentService
    {
        Task<IEnumerable<Komentar>> GetCommentsByFilmAsync(string naslovFilma);
        Task<HttpResponseMessage> CreateCommentAsync(Komentar komentar);
        Task<HttpResponseMessage> RemoveCommentAsync(Komentar komentar);
    }
}

