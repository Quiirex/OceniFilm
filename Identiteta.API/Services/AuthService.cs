using Identiteta.API.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

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
        if (uporabnik == null)
        {
            return null;
        }

        byte[]? sol = new byte[128 / 8];

        using (RNGCryptoServiceProvider? rngCsp = new())
        {
            rngCsp.GetNonZeroBytes(sol);
        }

        string? hashedGeslo = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: uporabnik?.Geslo ?? string.Empty,
            salt: sol,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 256 / 8
            ));

        uporabnik.Sol = Convert.ToBase64String(sol);
        uporabnik.Geslo = hashedGeslo;

        return uporabnik;
    }

    public bool VerifyPassword(string geslo, string shranjenHash, string shranjenaSol)
    {
        byte[]? solVBytih = Convert.FromBase64String(shranjenaSol);
        string? hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: geslo,
            salt: solVBytih,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 256 / 8
            ));

        return hash == shranjenHash;
    }

    public string GenerateJwtToken(Uporabnik uporabnik)
    {
        List<Claim>? claims = new()
        {
            new("email", uporabnik.Email ?? string.Empty),
            new("prikaznoIme", uporabnik.PrikaznoIme ?? string.Empty),
            new("id", uporabnik.Id)
        };

        SymmetricSecurityKey? key =
            new(Encoding.UTF8.GetBytes(_configuration.GetSection("JWT:Key").Value));

        SigningCredentials? signinCredentials = new(key, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken? tokenOptions = new JwtSecurityToken(
            issuer: _configuration.GetSection("JWT:Issuer").Value,
            audience: _configuration.GetSection("JWT:Audience").Value,
            claims: claims,
            expires: DateTime.Now.AddDays(1), // TODO Check if the token needs to be refreshed
            signingCredentials: signinCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }
}