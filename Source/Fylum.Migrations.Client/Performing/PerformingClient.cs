using Fylum.Migrations.SharedModels;
using Fylum.Migrations.SharedModels.PerformAllMigrations;
using Fylum.Migrations.SharedModels.PerformMigrationsUpTo;
using System.Net.Http.Json;

namespace Fylum.Migrations.Client.Performing;

public class PerformingClient : IPerformingClient
{
    private readonly HttpClient _httpClient;

    public PerformingClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<PerformAllMigrationsResponse> PerformAllMigrationsAsync(CancellationToken cancellationToken)
    {
        var content = new StringContent(string.Empty);
        var response = await _httpClient.PostAsync(
            EndpointRoutes.MigrationsPerformAllRoute, content, cancellationToken);

        if (!response.IsSuccessStatusCode)
            throw new Exception("Performing migrations failed");
        var migrationsResult = await response.Content.ReadFromJsonAsync<PerformAllMigrationsResponse>(cancellationToken)
            ?? throw new Exception("Invalid Performing migrations response");
        return migrationsResult;
    }
    public async Task<PerformAllMigrationsResponse> PerformAllMigrationsAsync()
        => await PerformAllMigrationsAsync(CancellationToken.None);

    public async Task<PerformMigrationsUpToResponse> PerformMigrationsUpToAsync(Guid upToMigrationId, CancellationToken cancellationToken)
    {
        var route = $"{EndpointRoutes.MigrationsPerformUpToRoute}/{upToMigrationId}";
        var content = new StringContent(string.Empty);
        var response = await _httpClient.PostAsync(route, content, cancellationToken);

        if (!response.IsSuccessStatusCode)
            throw new Exception("Performing migrations failed");
        var migrationsResult = await response.Content.ReadFromJsonAsync<PerformMigrationsUpToResponse>(cancellationToken)
            ?? throw new Exception("Invalid Performing migrations response");
        return migrationsResult;
    }
    public async Task<PerformMigrationsUpToResponse> PerformMigrationsUpToAsync(Guid upToMigrationId)
        => await PerformMigrationsUpToAsync(upToMigrationId, CancellationToken.None);
}
