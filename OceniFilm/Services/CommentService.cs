using Blazored.LocalStorage;
using OceniFilm.Models.Komentiranje;
using System.Net;
using System.Net.Http.Headers;

namespace OceniFilm.Services
{
    public class CommentService : ICommentService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ILocalStorageService _localStorageService;

        public CommentService(HttpClient httpClient, IConfiguration configuration, ILocalStorageService localStorageService)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _localStorageService = localStorageService;
        }

        public async Task<IEnumerable<Komentar>> GetCommentsByFilmAsync(string naslovFilma)
        {
            try
            {
                //return await _httpClient.GetFromJsonAsync<IEnumerable<Komentar>>(_configuration["GatewayUrl"] + "/komentarjiPoFilmu/" + naslovFilma);
                return await _httpClient.GetFromJsonAsync<IEnumerable<Komentar>>(_configuration["KomentiranjeService"] + "komentarjiPoFilmu/" + naslovFilma);
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
                string? jwt = await _localStorageService.GetItemAsync<string>("jwt");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
                //return await _httpClient.PostAsJsonAsync(_configuration["GatewayUrl"] + "/Komentar", komentar);
                return await _httpClient.PostAsJsonAsync(_configuration["KomentiranjeService"] + "api/Komentar", komentar);
            }
            catch (HttpRequestException)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        public async Task<HttpResponseMessage> RemoveCommentAsync(Komentar komentar)
        {
            try
            {
                string? jwt = await _localStorageService.GetItemAsync<string>("jwt");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
                //return await _httpClient.PostAsJsonAsync(_configuration["GatewayUrl"] + "/odstraniKomentar", komentar);
                return await _httpClient.PostAsJsonAsync(_configuration["KomentiranjeService"] + "odstraniKomentar", komentar);
            }
            catch (HttpRequestException)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}

