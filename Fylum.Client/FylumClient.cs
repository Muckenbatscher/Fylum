using Fylum.Shared;
using Fylum.Shared.Files;
using System.Net.Http.Json;

namespace Fylum.Client;

public class FylumClient : IFylumClient
{
    private readonly HttpClient _httpClient;

    public FylumClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<FileResponse> GetById(Guid id, CancellationToken cancellationToken)
    {
        var route = $"{EndpointRoutes.FileBaseRoute}/{id}";
        var response = await _httpClient.GetAsync(route, cancellationToken);

        if (!response.IsSuccessStatusCode)
            throw new Exception("Get file failed");
        var fieResult = await response.Content.ReadFromJsonAsync<FileResponse>(cancellationToken)
            ?? throw new Exception("Invalid file response");
        return fieResult;
    }
}