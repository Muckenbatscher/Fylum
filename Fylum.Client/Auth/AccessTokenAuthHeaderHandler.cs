using Fylum.Client.Auth.Token;
using System.Net;
using System.Net.Http.Headers;

namespace Fylum.Client.Auth;

public class AccessTokenAuthHeaderHandler : DelegatingHandler
{
    private readonly ITokenService _tokenService;

    public AccessTokenAuthHeaderHandler(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var token = await _tokenService.GetAccessTokenAsync(cancellationToken);
        if (!string.IsNullOrEmpty(token))
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await base.SendAsync(request, cancellationToken);

        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            await _tokenService.RefreshTokenAsync(cancellationToken);
            var newToken = await _tokenService.GetAccessTokenAsync(cancellationToken);

            if (!string.IsNullOrEmpty(newToken))
            {
                // IMPORTANT: We generally cannot reuse the same HttpRequestMessage object.
                // We must clone it or reset it, but for simple cases, updating the header works 
                // if the content hasn't been read.

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", newToken);

                response.Dispose();

                return await base.SendAsync(request, cancellationToken);
            }

            return response;
        }

        return response;
    }
}
