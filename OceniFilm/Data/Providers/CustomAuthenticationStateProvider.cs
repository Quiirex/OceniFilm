using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace OceniFilm.Data.Providers
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;

        public CustomAuthenticationStateProvider(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        private async Task<string> GetToken()
        {
            return await _localStorageService.GetItemAsync<string>("jwt"); ;
        }

        private static JwtSecurityToken ReadToken(string jwt)
        {
            JwtSecurityTokenHandler handler = new();
            return handler.ReadJwtToken(jwt);
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string jwt = await GetToken();

            if (string.IsNullOrEmpty(jwt))
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            JwtSecurityToken jwtDecoded = ReadToken(jwt);

            ClaimsIdentity claimsIdentity = new(new List<Claim>
            {
                new Claim(ClaimTypes.Email, jwtDecoded.Claims.First(x => x.Type == "email").Value),
                new Claim(ClaimTypes.Name, jwtDecoded.Claims.First(x => x.Type == "prikaznoIme").Value),
                new Claim(ClaimTypes.NameIdentifier, jwtDecoded.Claims.First(x => x.Type == "id").Value)
            }, "auth");

            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(claimsIdentity)));
        }
    }
}
