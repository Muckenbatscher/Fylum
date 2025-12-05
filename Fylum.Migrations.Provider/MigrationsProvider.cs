using Fylum.Migrations.Domain.Providing;
using Fylum.Migrations.Provider.Migrations;

namespace Fylum.Migrations.Provider;

public class MigrationsProvider : IMigrationsProvider
{
    private readonly Dictionary<Guid, ProvidedMigration> _knownMigrations;

    public MigrationsProvider()
    {
        _knownMigrations = new Dictionary<Guid, ProvidedMigration>();
        foreach (var migration in GetMigrations())
            _knownMigrations.Add(migration.Id, migration);
    }

    public IEnumerable<ProvidedMigration> GetMigrations()
    {
        yield return new MigrationsMigration().CreateMigration();
        yield return new UsersMigration().CreateMigration();
        yield return new RefreshKeysMigration().CreateMigration();
    }

    public ProvidedMigration? GetMigrationById(Guid id)
    {
        return _knownMigrations.TryGetValue(id, out var migration)
            ? migration
            : null;
    }
}