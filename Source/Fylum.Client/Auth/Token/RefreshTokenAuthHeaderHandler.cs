using Fylum.Client.Auth.Token.Storage;
using System.Net.Http.Headers;

namespace Fylum.Client.Auth.Token;

public class RefreshTokenAuthHeaderHandler : DelegatingHandler
{
    private readonly ITokenStorage _tokenStorage;
    public RefreshTokenAuthHeaderHandler(ITokenStorage tokenStorage)
    {
        _tokenStorage = tokenStorage;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var tokens = await _tokenStorage.GetTokenPairAsync();
        if (tokens == null || string.IsNullOrEmpty(tokens.RefreshToken))
            throw new InvalidOperationException("No refresh token available. Explicitly Login with credentials first.");

        var token = tokens?.RefreshToken;
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await base.SendAsync(request, cancellationToken);
        return response;
    }
}
