namespace Fylum.Migrations.Provider.Migrations;

internal class UsersMigration : MigrationFromEmbeddedResources
{
    public override Guid Id => Guid.Parse("3ead4e8f-16dd-4219-953a-600d0c8f035d");
    public override string Name => "1_Users";
    public override bool IsMinimallyRequired => true;

    protected override IEnumerable<string> ResourceFolderNameParts 
        => ["MigrationFiles", "1_Users"];

    protected override IEnumerable<string> ResourceNames
    {
        get
        {
            yield return "users.psql";
            yield return "user_groups.psql";
            yield return "user_group_members.psql";
            yield return "user_password_logins.psql";
            yield return "insert_admin_user.psql";
        }
    }
}
