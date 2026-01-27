namespace Fylum.Migrations.Domain.Providing;

public class MigrationScript
{
    public MigrationScript(string scriptCommandText)
    {
        ScriptCommandText = scriptCommandText;
    }

    public string ScriptCommandText { get; }
}