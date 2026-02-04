namespace Fylum.Migrations.Api.Common.Domain.Providing;

public class MigrationScript
{
    public MigrationScript(string scriptCommandText)
    {
        ScriptCommandText = scriptCommandText;
    }

    public string ScriptCommandText { get; }
}