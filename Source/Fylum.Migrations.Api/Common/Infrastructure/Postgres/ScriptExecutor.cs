using Dapper;
using Fylum.Core.Domain;
using Fylum.Migrations.Api.Common.Domain.Perform;

namespace Fylum.Migrations.Api.Common.Infrastructure.Postgres;

public class ScriptExecutor : IScriptExecutor
{
    private readonly IUnitOfWorkTransactionFactory _transactionFactory;

    public ScriptExecutor(IUnitOfWorkTransactionFactory transactionfactory)
    {
        _transactionFactory = transactionfactory;
    }

    public void Execute(string script)
    {
        var transaction = _transactionFactory.GetTransaction();
        transaction.Connection.Execute(script,
            transaction: transaction.Transaction);
    }
}