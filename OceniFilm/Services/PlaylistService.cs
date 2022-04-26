using System;
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
    }
}

