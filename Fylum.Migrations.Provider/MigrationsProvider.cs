using Fylum.Migrations.Domain;
using Fylum.Migrations.Provider.Migrations;

namespace Fylum.Migrations.Provider
{
    public class MigrationsProvider : IMigrationsProvider
    {
        private readonly Dictionary<Guid, Migration> _knownMigrations;

        public MigrationsProvider()
        {
            _knownMigrations = new Dictionary<Guid, Migration>();
            foreach (var migration in GetMigrations())
                _knownMigrations.Add(migration.Id, migration);
        }


        public IEnumerable<Migration> GetMigrations()
        {
            yield return new MigrationsMigration().CreateMigration();
            yield return new UsersMigration().CreateMigration();
        }

        public Migration? GetMigrationById(Guid id)
        {
            if (_knownMigrations.TryGetValue(id, out var migration))
                return migration;

            return null;
        }
    }
}
