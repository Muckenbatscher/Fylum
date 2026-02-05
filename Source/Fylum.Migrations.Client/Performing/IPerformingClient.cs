using Fylum.Migrations.SharedModels.PerformAllMigrations;
using Fylum.Migrations.SharedModels.PerformMigrationsUpTo;

namespace Fylum.Migrations.Client.Performing;

public interface IPerformingClient
{
    Task<PerformAllMigrationsResponse> PerformAllMigrationsAsync(CancellationToken cancellationToken);
    Task<PerformAllMigrationsResponse> PerformAllMigrationsAsync();

    Task<PerformMigrationsUpToResponse> PerformMigrationsUpToAsync(Guid upToMigrationId, CancellationToken cancellationToken);
    Task<PerformMigrationsUpToResponse> PerformMigrationsUpToAsync(Guid upToMigrationId);
}
