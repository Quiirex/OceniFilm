using System;
using System.Net;
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
                return await _httpClient.GetFromJsonAsync<IEnumerable<Komentar>>(_configuration["KomentiranjeAPI"] + "/komentarjiPoFilmu/" + naslovFilma);
            }
            catch (HttpRequestException)
            {
                return Enumerable.Empty<Komentar>();
            }
        }

        public async Task<HttpResponseMessage> CreateCommentAsync(Komentar komentar)
        {
            try
            {
                return await _httpClient.PostAsJsonAsync(_configuration["KomentiranjeAPI"] + "/api/Komentar", komentar);
            }
            catch (HttpRequestException)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        public async Task<HttpResponseMessage> RemoveCommentAsync(int id)
        {
            try
            {
                return await _httpClient.DeleteAsync(_configuration["KomentiranjeAPI"] + "/api/Komentar/" + id);
            }
            catch (HttpRequestException)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}

