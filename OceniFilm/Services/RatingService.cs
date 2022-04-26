using System;
using System.Net;
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

        public async Task<HttpResponseMessage> CreateRatingAsync(Ocena ocena)
        {
            try
            {
                return await _httpClient.PostAsJsonAsync(_configuration["OcenjevanjeAPI"] + "/api/Ocena", ocena);
            }
            catch (HttpRequestException)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        public async Task<HttpResponseMessage> EditRatingAsync(int id, Ocena ocena)
        {
            try
            {
                return await _httpClient.PutAsJsonAsync(_configuration["OcenjevanjeAPI"] + "/api/Ocena/" + id, ocena); // obviously not correct yet
            }
            catch (HttpRequestException)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        public async Task<HttpResponseMessage> RemoveRatingAsync(int id)
        {
            try
            {
                return await _httpClient.DeleteAsync(_configuration["OcenjevanjeAPI"] + "/api/Ocena/" + id); // obviously not correct yet
            }
            catch (HttpRequestException)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}

