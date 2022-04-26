using System;
using OceniFilm.Models.Komentiranje;

namespace OceniFilm.Services
{
	public class CommentService : ICommentService
	{
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public CommentService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<IEnumerable<Komentar>> GetCommentsByFilmAsync(string naslovFilma)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<Komentar>>(_configuration["KomentiranjeAPI"] + "/api/Komentar/komentarjiPoFilmu/" + naslovFilma);
            }
            catch (HttpRequestException)
            {
                return Enumerable.Empty<Komentar>();
            }
        }
    }
}

