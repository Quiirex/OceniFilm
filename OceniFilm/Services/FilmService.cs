using OceniFilm.Models.Videoteka;

namespace OceniFilm.Services
{
    public class FilmService : IFilmService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public FilmService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<IEnumerable<Film>> GetFilmiAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<Film>>(_configuration["VideotekaAPI"] + "/api/Videoteka");
            }
            catch (HttpRequestException)
            {
                return Enumerable.Empty<Film>();
            }
        }

        public async Task<Film> GetFilmByTitleAsync(string naslovFilma)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Film>(_configuration["VideotekaAPI"] + "/api/Videoteka/film/" + naslovFilma);
            }
            catch (HttpRequestException)
            {
                return new Film();
            }
        }
    }
}
