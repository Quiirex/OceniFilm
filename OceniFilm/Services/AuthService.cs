using OceniFilm.Models;

namespace OceniFilm.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public AuthService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<IEnumerable<Uporabnik>> GetUporabniki()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Uporabnik>>(_configuration["GatewayUrl"] + "/api/Identiteta");
        }

        public async Task<Uporabnik> GetUporabnikById(string id)
        {
            return await _httpClient.GetFromJsonAsync<Uporabnik>(_configuration["GatewayUrl"] + "/api/Identiteta/" + id);
        }

        public async Task<HttpResponseMessage> Register(RegistracijaUporabnika novUporabnik)
        {
            return await _httpClient.PostAsJsonAsync(_configuration["GatewayUrl"] + "/api/Identiteta/registracija", novUporabnik);
        }

        public async Task<HttpResponseMessage> Login(PrijavaUporabnika uporabnik)
        {
            return await _httpClient.PostAsJsonAsync(_configuration["GatewayUrl"] + "/api/Identiteta/prijava", uporabnik);
        }
    }
}
