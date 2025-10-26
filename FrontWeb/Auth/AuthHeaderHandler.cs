using System.Net.Http.Headers;

namespace FrontWeb.Auth
{
    public class AuthHeaderHandler : DelegatingHandler
    {
        private readonly LocalStorageService _localStorage;

        public AuthHeaderHandler(LocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await _localStorage.GetItem<string>("authToken");

            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}