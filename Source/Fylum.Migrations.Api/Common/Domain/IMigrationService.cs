namespace Fylum.Migrations.Api.Common.Domain;

public interface IMigrationService
{
    IEnumerable<Migration> GetMigrations();
    Migration? GetMigration(Guid id);
    IEnumerable<Migration> GetUnperformedMigrations();
}