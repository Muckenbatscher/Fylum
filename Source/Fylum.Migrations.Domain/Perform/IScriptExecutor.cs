namespace Fylum.Migrations.Domain.Perform;

public interface IScriptExecutor
{
    void Execute(string script);
}