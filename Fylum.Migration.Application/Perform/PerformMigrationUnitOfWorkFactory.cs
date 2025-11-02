using Fylum.Application;
using Fylum.Domain.UnitOfWork;
using Fylum.Migration.Domain.Perform;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Migration.Application.Perform
{
    public class PerformMigrationUnitOfWorkFactory : UnitOfWorkFactory, IPerformMigrationUnitOfWorkFactory
    {
        public PerformMigrationUnitOfWorkFactory(IServiceScopeFactory serviceScopeFactory) : 
            base(serviceScopeFactory)
        {
        }

        public PerformMigrationUnitOfWork Create()
        {
            CreateScope();
            
            var transactionFactory = GetScopedService<IUnitOfWorkTransactionFactory>();
            var migrationsRepository = GetScopedService<IPerformedMigrationsRepository>();
            var scriptExecutor = GetScopedService<IScriptExecutor>();

            return new PerformMigrationUnitOfWork(
                transactionFactory,
                migrationsRepository,
                scriptExecutor);
        }
    }
}
