using OceniFilm.Models;

namespace OceniFilm.Services
{
    public interface IAuthService
    {
        Task<IEnumerable<Uporabnik>> GetUporabnikiAsync();
        Task<Uporabnik> GetUporabnikByIdAsync(string id);
        Task<HttpResponseMessage> RegisterAsync(RegistracijaUporabnika novUporabnik);
        Task<HttpResponseMessage> LoginAsync(PrijavaUporabnika uporabnik);
    }
}
