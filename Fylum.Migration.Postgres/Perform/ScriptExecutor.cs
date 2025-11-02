using Dapper;
using Fylum.Domain.UnitOfWork;
using Fylum.Migration.Domain.Perform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Migration.Postgres.Perform
{
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
}
