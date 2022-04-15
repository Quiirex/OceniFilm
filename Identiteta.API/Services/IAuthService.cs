using Identiteta.API.Models;

namespace Identiteta.API.Services;

public interface IAuthService
{
    Uporabnik? HashPassword(Uporabnik uporabnik);
    bool VerifyPassword(string geslo, string shranjenHash, string shranjenaSol);
    string GenerateJwtToken(Uporabnik uporabnik);
}