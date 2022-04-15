using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Identiteta.API.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;

namespace Identiteta.API.Services;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;

    public AuthService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Uporabnik? HashPassword(Uporabnik uporabnik)
    {
        if (uporabnik == null) return null;

        var sol = new byte[128 / 8];

        using (var rngCsp = new RNGCryptoServiceProvider())
        {
            rngCsp.GetNonZeroBytes(sol);
        }

        var hashGeslo = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            uporabnik?.Geslo ?? string.Empty,
            sol,
            KeyDerivationPrf.HMACSHA512,
            10000,
            256 / 8));


        uporabnik.Geslo = hashGeslo;
        uporabnik.Sol = Convert.ToBase64String(sol);

        return uporabnik;
    }

    public bool VerifyPassword(string geslo, string shranjenHash, string shranjenaSol)
    {
        var solBytes = Convert.FromBase64String(shranjenaSol);
        var hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            geslo,
            solBytes,
            KeyDerivationPrf.HMACSHA512,
            10000,
            256 / 8));

        return hash == shranjenHash;
    }

    public string GenerateJwtToken(Uporabnik uporabnik)
    {
        var claims = new List<Claim>
        {
            new("email", uporabnik.Email ?? string.Empty),
            new("username", uporabnik.PrikaznoIme ?? string.Empty),
            new("Id", uporabnik.Id)
        };

        var secretKey =
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha512Signature);

        var tokenOptions = new JwtSecurityToken(
            "https://localhost:7165",
            claims: claims,
            expires: DateTime.Now.AddDays(1), // TODO Check if the token needs to be refreshed
            signingCredentials: signinCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }
}