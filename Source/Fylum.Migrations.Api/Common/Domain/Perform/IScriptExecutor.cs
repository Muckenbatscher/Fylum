namespace Fylum.Migrations.Api.Common.Domain.Perform;

public interface IScriptExecutor
{
    void Execute(string script);
}