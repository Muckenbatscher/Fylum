namespace Fylum.Migrations.Domain.Providing;

public interface IMigrationsProvider
{
    IEnumerable<ProvidedMigration> GetMigrations();
    ProvidedMigration? GetMigrationById(Guid id);
}