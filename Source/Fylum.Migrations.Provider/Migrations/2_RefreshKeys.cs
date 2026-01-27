namespace Fylum.Migrations.Provider.Migrations;

internal class RefreshKeysMigration : MigrationFromEmbeddedResources
{
    public override Guid Id => Guid.Parse("68413381-2EA6-4743-BA38-8941CC137D2E");
    public override string Name => "2_RefreshKeys";

    protected override IEnumerable<string> ResourceFolderNameParts
        => ["MigrationFiles", "2_RefreshKeys"];

    protected override IEnumerable<string> ResourceNames
    {
        get
        {
            yield return "user_refresh_keys.psql";
        }
    }
}