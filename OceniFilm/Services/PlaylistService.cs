using System;
using System.Net;
using System.Net.Http.Headers;
using Blazored.LocalStorage;
using OceniFilm.Models.Seznami;

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
                var jwt = await _localStorageService.GetItemAsync<string>("jwt");
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
                var jwt = await _localStorageService.GetItemAsync<string>("jwt");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
                return await _httpClient.PostAsJsonAsync(_configuration["SeznamiAPI"] + "/api/SeznamFilmov", seznamFilmov);
            }
            catch (HttpRequestException)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        public async Task<HttpResponseMessage> EditPlaylistAsync(SeznamFilmov seznamFilmov)
        {
            try
            {
                var jwt = await _localStorageService.GetItemAsync<string>("jwt");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
                return await _httpClient.PutAsJsonAsync(_configuration["SeznamiAPI"] + "/api/SeznamFilmov/", seznamFilmov);
            }
            catch (HttpRequestException)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        public async Task<HttpResponseMessage> RemovePlaylistAsync(SeznamFilmov seznamFilmov)
        {
            try
            {
                var jwt = await _localStorageService.GetItemAsync<string>("jwt");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
                return await _httpClient.PostAsJsonAsync(_configuration["SeznamiAPI"] + "/odstraniSeznamFilmov", seznamFilmov);
            }
            catch (HttpRequestException)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}

