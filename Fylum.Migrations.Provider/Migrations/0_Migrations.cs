namespace Fylum.Migrations.Provider.Migrations;

internal class MigrationsMigration : MigrationFromEmbeddedResources
{
    public override Guid Id => Guid.Parse("d8d4a2b4-edc7-4b40-a618-f196bf3eb633");
    public override string Name => "0_Migrations";


    protected override IEnumerable<string> ResourceFolderNameParts
        => ["MigrationFiles", "0_Migrations"];

    protected override IEnumerable<string> ResourceNames
    {
        get
        {
            yield return "migrations.psql";
            yield return "migrations_performed.psql";
        }
    }
}