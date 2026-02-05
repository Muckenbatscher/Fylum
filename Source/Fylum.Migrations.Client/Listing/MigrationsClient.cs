using Fylum.Migrations.SharedModels;
using Fylum.Migrations.SharedModels.GetMigrationById;
using Fylum.Migrations.SharedModels.GetMigrations;
using System.Net.Http.Json;

namespace Fylum.Migrations.Client.Listing;

public class MigrationsClient : IMigrationsClient
{
    private readonly HttpClient _httpClient;

    public MigrationsClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GetMigrationsResponse> GetMigrationsAsync(CancellationToken cancellationToken)
    {
        var response = await _httpClient.GetAsync(
            EndpointRoutes.MigrationsBaseRoute, cancellationToken);

        if (!response.IsSuccessStatusCode)
            throw new Exception("Get migrations failed");
        var migrationsResult = await response.Content.ReadFromJsonAsync<GetMigrationsResponse>(cancellationToken)
            ?? throw new Exception("Invalid migrations response");
        return migrationsResult;
    }
    public async Task<GetMigrationsResponse> GetMigrationsAsync() => await GetMigrationsAsync(CancellationToken.None);

    public async Task<GetMigrationByIdResponse> GetMigrationByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var route = $"{EndpointRoutes.MigrationsBaseRoute}/{{{id}}}";
        var response = await _httpClient.GetAsync(route, cancellationToken);

        if (!response.IsSuccessStatusCode)
            throw new Exception("Get migration failed");
        var migrationResult = await response.Content.ReadFromJsonAsync<GetMigrationByIdResponse>(cancellationToken)
            ?? throw new Exception("Invalid migration response");
        return migrationResult;
    }
    public async Task<GetMigrationByIdResponse> GetMigrationByIdAsync(Guid id) => await GetMigrationByIdAsync(id, CancellationToken.None);
}
