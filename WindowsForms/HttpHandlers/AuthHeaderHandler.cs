using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsForms.HttpHandlers
{
    public class AuthHeaderHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (UserSession.IsLoggedIn)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("bearer", UserSession.Token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}