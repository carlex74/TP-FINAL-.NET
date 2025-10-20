using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FrontWeb.Auth
{
    public class ApiAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly LocalStorageService _localStorage;

        public ApiAuthenticationStateProvider(LocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var savedToken = await _localStorage.GetItem<string>("authToken");

            if (string.IsNullOrWhiteSpace(savedToken))
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(savedToken);
            if (token.ValidTo < System.DateTime.UtcNow)
            {
                await _localStorage.RemoveItem("authToken");
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            return CreateAuthenticationState(savedToken);
        }

        public void MarkUserAsAuthenticated(string token)
        {
            var authState = Task.FromResult(CreateAuthenticationState(token));
            NotifyAuthenticationStateChanged(authState);
        }

        public void MarkUserAsLoggedOut()
        {
            var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
            var authState = Task.FromResult(new AuthenticationState(anonymousUser));
            NotifyAuthenticationStateChanged(authState);
        }

        private AuthenticationState CreateAuthenticationState(string token)
        {
            var claims = new JwtSecurityTokenHandler().ReadJwtToken(token).Claims;

            var identity = new ClaimsIdentity(
                claims: claims,
                authenticationType: "jwt",
                nameType: ClaimTypes.Name,
                roleType: ClaimTypes.Role 
            );

            var user = new ClaimsPrincipal(identity);
            return new AuthenticationState(user);
        }
    }
}