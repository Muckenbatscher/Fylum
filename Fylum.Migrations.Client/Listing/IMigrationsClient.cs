using Fylum.Migrations.Api.Shared;

namespace Fylum.Migrations.Client.Listing;

public interface IMigrationsClient
{
    Task<MigrationResponse> GetMigrationByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<MultipleMigrationsResponse> GetMigrationsAsync(CancellationToken cancellationToken);
}
