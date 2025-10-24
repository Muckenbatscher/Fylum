using Fylum.Domain.UnitOfWork;
using Fylum.Migration.Domain.PerformedMigrations;
using Fylum.Migration.PostgreSql.ScriptExecution;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Migration.PostgreSql.PerformMigration
{
    public class PerformMigrationUnitOfWorkFactory : IPerformMigrationUnitOfWorkFactory
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public PerformMigrationUnitOfWorkFactory(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public PerformMigrationUnitOfWork Create()
        {
            var scope = _serviceScopeFactory.CreateScope();
            
            var transactionFactory = scope.ServiceProvider.GetRequiredService<IUnitOfWorkTransactionFactory>();
            var migrationsRepository = scope.ServiceProvider.GetRequiredService<IPerformedMigrationsRepository>();
            var scriptExecutor = scope.ServiceProvider.GetRequiredService<IScriptExecutor>();

            return new PerformMigrationUnitOfWork(
                transactionFactory,
                migrationsRepository,
                scriptExecutor);
        }
    }
}
