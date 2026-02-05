namespace Fylum.Migrations.Api.Common.Domain.Providing;

public interface IMigrationsProvider
{
    IEnumerable<ProvidedMigration> GetMigrations();
    ProvidedMigration? GetMigrationById(Guid id);
}