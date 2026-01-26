namespace Fylum.Migrations.Provider.Migrations;

internal class FoldersMigration : MigrationFromEmbeddedResources
{
    public override Guid Id => Guid.Parse("B7229CA2-C0B7-46E4-983D-59D92F70E8EF");
    public override string Name => "3_Folders";

    protected override IEnumerable<string> ResourceFolderNameParts
        => ["MigrationFiles", "3_Folders"];

    protected override IEnumerable<string> ResourceNames
    {
        get
        {
            yield return "folders.psql";
            yield return "insert_root_folder.psql";
        }
    }
}