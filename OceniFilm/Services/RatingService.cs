using Blazored.LocalStorage;
using OceniFilm.Models.Ocenjevanje;
using System.Net;
using System.Net.Http.Headers;

namespace OceniFilm.Services
{
    public class RatingService : IRatingService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ILocalStorageService _localStorageService;

        public RatingService(HttpClient httpClient, IConfiguration configuration, ILocalStorageService localStorageService)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _localStorageService = localStorageService;
        }

        public async Task<Ocena> GetOcenaByTitleAndUserAsync(string naslovFilma, string prikaznoIme)
        {
            try
            {
                //return await _httpClient.GetFromJsonAsync<Ocena>(_configuration["GatewayUrl"] + "/poFilmuInUporabniku/" + naslovFilma + "/" + prikaznoIme);
                return await _httpClient.GetFromJsonAsync<Ocena>(_configuration.GetServiceUri("ocenjevanje-api") + "poFilmuInUporabniku/" + naslovFilma + "/" + prikaznoIme);
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
                string? jwt = await _localStorageService.GetItemAsync<string>("jwt");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
                //return await _httpClient.PostAsJsonAsync(_configuration["GatewayUrl"] + "/Ocena/", ocena);
                return await _httpClient.PostAsJsonAsync(_configuration.GetServiceUri("ocenjevanje-api") + "api/Ocena", ocena);
            }
            catch (HttpRequestException)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        public async Task<HttpResponseMessage> EditRatingAsync(Ocena ocena)
        {
            try
            {
                string? jwt = await _localStorageService.GetItemAsync<string>("jwt");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
                //return await _httpClient.PutAsJsonAsync(_configuration["GatewayUrl"] + "/Ocena/", ocena);
                return await _httpClient.PutAsJsonAsync(_configuration.GetServiceUri("ocenjevanje-api") + "api/Ocena", ocena);
            }
            catch (HttpRequestException)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}

