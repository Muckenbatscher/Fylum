namespace Fylum.Migrations.Api.Common.Domain.Perform;

public interface IPerformedMigrationsRepository
{
    IEnumerable<PerformedMigration> GetPerformedMigrations();
    PerformedMigration? GetPerformedMigrationById(Guid id);

    void AddPerformedMigration(PerformedMigration performedMigration);
}