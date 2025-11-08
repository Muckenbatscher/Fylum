using Fylum.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Fylum.Migrations.Domain.Perform
{
    public class PerformMigrationUnitOfWork : UnitOfWork, IUnitOfWork
    {
        public IPerformedMigrationsRepository PerformedMigrationsRepository { get; private set; }
        public IScriptExecutor ScriptExecutor { get; private set; }

        public PerformMigrationUnitOfWork(IUnitOfWorkTransactionFactory transactionFactory, 
            IPerformedMigrationsRepository performedMigrationsRepository, 
            IScriptExecutor scriptExecutor) : 
            base(transactionFactory)
        {
            PerformedMigrationsRepository = performedMigrationsRepository;
            ScriptExecutor = scriptExecutor;
        }
    }
}
