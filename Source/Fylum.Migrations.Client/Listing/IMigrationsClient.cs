using Fylum.Migrations.SharedModels.GetMigrationById;
using Fylum.Migrations.SharedModels.GetMigrations;

namespace Fylum.Migrations.Client.Listing;

public interface IMigrationsClient
{
    Task<GetMigrationByIdResponse> GetMigrationByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<GetMigrationByIdResponse> GetMigrationByIdAsync(Guid id);

    Task<GetMigrationsResponse> GetMigrationsAsync(CancellationToken cancellationToken);
    Task<GetMigrationsResponse> GetMigrationsAsync();
}
