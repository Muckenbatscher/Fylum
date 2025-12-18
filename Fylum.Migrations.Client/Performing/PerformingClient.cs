using Fylum.Migrations.Api.Shared;
using System.Net.Http.Json;

namespace Fylum.Migrations.Client.Performing;

public class PerformingClient : IPerformingClient
{
    private readonly HttpClient _httpClient;

    public PerformingClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<PerformMigrationsResponse> PerformAllMigrationsAsync(CancellationToken cancellationToken)
    {
        var content = new StringContent(string.Empty);
        var response = await _httpClient.PostAsync(
            EndpointRoutes.MigrationsPerformAllRoute, content, cancellationToken);

        if (!response.IsSuccessStatusCode)
            throw new Exception("Performing migrations failed");
        var migrationsResult = await response.Content.ReadFromJsonAsync<PerformMigrationsResponse>(cancellationToken)
            ?? throw new Exception("Invalid Performing migrations response");
        return migrationsResult;
    }
    public async Task<PerformMigrationsResponse> PerformMigrationsUpToAsync(Guid upToMigrationId, CancellationToken cancellationToken)
    {
        var route = $"{EndpointRoutes.MigrationsPerformUpToRoute}/{upToMigrationId}";
        var content = new StringContent(string.Empty);
        var response = await _httpClient.PostAsync(route, content, cancellationToken);

        if (!response.IsSuccessStatusCode)
            throw new Exception("Performing migrations failed");
        var migrationsResult = await response.Content.ReadFromJsonAsync<PerformMigrationsResponse>(cancellationToken)
            ?? throw new Exception("Invalid Performing migrations response");
        return migrationsResult;
    }
}
