using Blazored.LocalStorage;
using OceniFilm.Models.Seznami;
using System.Net.Http.Headers;

namespace OceniFilm.Services
{
    public class PlaylistService : IPlaylistService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ILocalStorageService _localStorageService;

        public PlaylistService(HttpClient httpClient, IConfiguration configuration, ILocalStorageService localStorageService)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _localStorageService = localStorageService;
        }

        public async Task<IEnumerable<SeznamFilmov>> GetSeznamFilmovByUserAsync(string prikaznoIme)
        {
            try
            {
                string? jwt = await _localStorageService.GetItemAsync<string>("jwt");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
                return await _httpClient.GetFromJsonAsync<IEnumerable<SeznamFilmov>>(_configuration["SeznamiAPI"] + "/poUporabniku/" + prikaznoIme);
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
                string? jwt = await _localStorageService.GetItemAsync<string>("jwt");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
                return await _httpClient.PostAsJsonAsync(_configuration["SeznamiAPI"] + "/api/SeznamFilmov", seznamFilmov);
            }
            catch (HttpRequestException)
            {
                throw new HttpRequestException("");
            }
        }

        public async Task<HttpResponseMessage> AddToPlaylistAsync(string prikaznoIme, string nazivSeznama, Film film)
        {
            try
            {
                string? jwt = await _localStorageService.GetItemAsync<string>("jwt");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
                return await _httpClient.PostAsJsonAsync(_configuration["SeznamiAPI"] + "/Dodaj/" + prikaznoIme + "/" + nazivSeznama, film);
            }
            catch (HttpRequestException)
            {
                throw new HttpRequestException("");
            }
        }

        public async Task<HttpResponseMessage> RemoveFromPlaylistAsync(string prikaznoIme, string nazivSeznama, Film film)
        {
            try
            {
                string? jwt = await _localStorageService.GetItemAsync<string>("jwt");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
                return await _httpClient.PostAsJsonAsync(_configuration["SeznamiAPI"] + "/Odstrani/" + prikaznoIme + "/" + nazivSeznama, film);
            }
            catch (HttpRequestException)
            {
                throw new HttpRequestException("");
            }
        }

        public async Task<HttpResponseMessage> RemovePlaylistAsync(SeznamFilmov seznamFilmov)
        {
            try
            {
                string? jwt = await _localStorageService.GetItemAsync<string>("jwt");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
                return await _httpClient.PostAsJsonAsync(_configuration["SeznamiAPI"] + "/odstraniSeznamFilmov", seznamFilmov);
            }
            catch (HttpRequestException)
            {
                throw new HttpRequestException("");
            }
        }
    }
}

