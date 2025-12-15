using Fylum.Migrations.Api.Shared;

namespace Fylum.Migrations.Client.Performing;

public interface IPerformingClient
{
    Task<PerformMigrationsResponse> PerformAllMigrationsAsync(CancellationToken cancellationToken);
    Task<PerformMigrationsResponse> PerformMigrationsUpToAsync(Guid upToMigrationId, CancellationToken cancellationToken);
}
