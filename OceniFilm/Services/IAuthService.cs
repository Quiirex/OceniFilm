using OceniFilm.Models;

namespace OceniFilm.Services
{
    public interface IAuthService
    {
        Task<IEnumerable<Uporabnik>> GetUporabniki();
        Task<Uporabnik> GetUporabnikById(string id);
        Task<HttpResponseMessage> Register(RegistracijaUporabnika novUporabnik);
        Task<HttpResponseMessage> Login(PrijavaUporabnika uporabnik);
    }
}
