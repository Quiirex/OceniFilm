using System;
using System.Net;
using OceniFilm.Models.Seznami;

namespace OceniFilm.Services
{
	public class PlaylistService : IPlaylistService
	{
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public PlaylistService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<IEnumerable<SeznamFilmov>> GetSeznamFilmovByUserAsync(string guid)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<SeznamFilmov>>(_configuration["SeznamiAPI"] + "/api/SeznamFilmov/poUporabniku/" + guid);
            }
            catch (HttpRequestException)
            {
                return Enumerable.Empty<SeznamFilmov>();
            }
        }

        public async Task<HttpResponseMessage> CreatePlaylistAsync(SeznamFilmov seznamFilmov)
        {
            try
            {
                return await _httpClient.PostAsJsonAsync(_configuration["SeznamiAPI"] + "/api/SeznamFilmov", seznamFilmov);
            }
            catch (HttpRequestException)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        public async Task<HttpResponseMessage> EditPlaylistAsync(int id, SeznamFilmov seznamFilmov) // fix this
        {
            try
            {
                return await _httpClient.PutAsJsonAsync(_configuration["SeznamiAPI"] + "/api/SeznamFilmov/" + id, seznamFilmov);
            }
            catch (HttpRequestException)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        public async Task<HttpResponseMessage> RemovePlaylistAsync(int id) // fix this
        {
            try
            {
                return await _httpClient.DeleteAsync(_configuration["SeznamiAPI"] + "/api/SeznamFilmov/" + id);
            }
            catch (HttpRequestException)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}

