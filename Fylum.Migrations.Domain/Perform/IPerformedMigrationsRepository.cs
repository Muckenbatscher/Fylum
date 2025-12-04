namespace Fylum.Migrations.Domain.Perform;

public interface IPerformedMigrationsRepository
{
    IEnumerable<PerformedMigration> GetPerformedMigrations();
    PerformedMigration? GetPerformedMigrationById(Guid id);

    void AddPerformedMigration(PerformedMigration performedMigration);
}