namespace Fylum.Migrations.Domain.Providing;

public class ProvidedMigration
{
    private ProvidedMigration(Guid id, string name, IEnumerable<MigrationScript> migrationScripts)
    {
        Id = id;
        Name = name;
        MigrationScripts = migrationScripts;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public IEnumerable<MigrationScript> MigrationScripts { get; private set; }


    public static ProvidedMigration CreateNew(string name)
        => new ProvidedMigration(Guid.NewGuid(), name, Enumerable.Empty<MigrationScript>());

    public static ProvidedMigration CreateNew(string name, IEnumerable<MigrationScript> migrationScripts)
        => new ProvidedMigration(Guid.NewGuid(), name, migrationScripts);

    public static ProvidedMigration Create(Guid id, string name, IEnumerable<MigrationScript> migrationScripts)
        => new ProvidedMigration(id, name, migrationScripts);
    
    public static ProvidedMigration Create(Guid id, string name)
        => new ProvidedMigration(id, name, Enumerable.Empty<MigrationScript>());
}
