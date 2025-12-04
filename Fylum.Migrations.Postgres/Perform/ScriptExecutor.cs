using Dapper;
using Fylum.Domain.UnitOfWork;
using Fylum.Migrations.Domain.Perform;

namespace Fylum.Migrations.Postgres.Perform;

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