using System;
using OceniFilm.Models.Ocenjevanje;

namespace OceniFilm.Services
{
	public class RatingService : IRatingService
	{
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public RatingService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<Ocena> GetOcenaByTitleAndUserAsync(string naslovFilma, string guid)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Ocena>(_configuration["OcenjevanjeAPI"] + "/api/Ocena/poFilmuInUporabniku/" + naslovFilma + "/" + guid);
            }
            catch (HttpRequestException)
            {
                return new Ocena();
            }
        }
    }
}

