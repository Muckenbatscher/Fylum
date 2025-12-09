using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace Fylum.Client.HttpMessaging;

internal abstract class TypedJsonContentClient
{
    private readonly HttpClient _httpClient;

    public TypedJsonContentClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    private Exception GetExceptionForResponse(HttpResponseMessage response)
    {
        return response.StatusCode switch
        {
            HttpStatusCode.NotFound => new NotFoundException(),
            HttpStatusCode.Unauthorized => new UnauthorizedException(),
            _ => new HttpStatusException(response.StatusCode)
        };
    }

    public async Task<TResponse> GetAsync<TResponse>(Uri uri, CancellationToken cancellationToken)
    {
        var response = await _httpClient.GetAsync(uri, cancellationToken);
        if (!response.IsSuccessStatusCode)
            throw GetExceptionForResponse(response);

        var resultContent = await response.Content.ReadAsStringAsync(cancellationToken);
        return JsonSerializer.Deserialize<TResponse>(resultContent)
            ?? throw new JsonParsingException(typeof(TResponse), resultContent);
    }
    public async Task<TResponse> PostAsync<TRequest, TResponse>(Uri uri, TRequest request, CancellationToken cancellationToken)
    {
        var content = JsonContent.Create(request);
        var response = await _httpClient.PostAsync(uri, content, cancellationToken);
        if (!response.IsSuccessStatusCode)
            throw GetExceptionForResponse(response);

        var resultContent = await response.Content.ReadAsStringAsync(cancellationToken);
        return JsonSerializer.Deserialize<TResponse>(resultContent)
            ?? throw new JsonParsingException(typeof(TResponse), resultContent);
    }
    public async Task PostAsync<TRequest>(Uri uri, TRequest request, CancellationToken cancellationToken)
    {
        var content = JsonContent.Create(request);
        var response = await _httpClient.PostAsync(uri, content, cancellationToken);
        if (!response.IsSuccessStatusCode)
            throw GetExceptionForResponse(response);
    }
}
