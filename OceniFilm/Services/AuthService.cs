using Blazored.LocalStorage;
using OceniFilm.Models;
using System.Net;

namespace OceniFilm.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ILocalStorageService _localStorageService;

        public AuthService(HttpClient httpClient, IConfiguration configuration, ILocalStorageService localStorageService)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _localStorageService = localStorageService;
        }

        public async Task<Uporabnik> GetUporabnikByIdAsync(string id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Uporabnik>(_configuration["GatewayUrl"] + "/Identiteta/" + id);
            }
            catch (HttpRequestException)
            {
                return new Uporabnik();
            }
        }

        public async Task<HttpResponseMessage> RegisterAsync(RegistracijaUporabnika novUporabnik)
        {
            try
            {
                return await _httpClient.PostAsJsonAsync(_configuration["GatewayUrl"] + "/Identiteta/registracija", novUporabnik);
            }
            catch (HttpRequestException)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        public async Task<HttpResponseMessage> LoginAsync(PrijavaUporabnika uporabnik)
        {
            try
            {
                return await _httpClient.PostAsJsonAsync(_configuration["GatewayUrl"] + "/Identiteta/prijava", uporabnik);
            }
            catch (HttpRequestException)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}
