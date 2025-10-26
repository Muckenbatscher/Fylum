using Fylum.Domain.UnitOfWork;
using Fylum.Migration.Domain.PerformedMigrations;
using Fylum.Migration.Postgres.ScriptExecution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Fylum.Migration.Postgres.PerformMigration
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
