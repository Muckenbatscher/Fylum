using Fylum.Migrations.Api.Shared;

namespace Fylum.Migrations.Client.Listing;

public interface IMigrationsClient
{
    Task<MigrationResponse> GetMigrationByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<MigrationResponse> GetMigrationByIdAsync(Guid id);

    Task<MultipleMigrationsResponse> GetMigrationsAsync(CancellationToken cancellationToken);
    Task<MultipleMigrationsResponse> GetMigrationsAsync();
}
