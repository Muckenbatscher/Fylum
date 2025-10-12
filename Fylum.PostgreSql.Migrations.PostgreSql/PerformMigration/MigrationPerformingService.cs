using Fylum.PostgreSql.Migration.Application.PerformMigration;
using Fylum.PostgreSql.Migration.Domain.PerformedMigrations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.PostgreSql.Migrations.PostgreSql.PerformMigration
{
    public class MigrationPerformingService : IMigrationPerformingService
    {
        private readonly IPerformMigrationUnitOfWorkFactory _unitOfWorkFactory;
        public MigrationPerformingService(IPerformMigrationUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public void Perform(Migration.Domain.Migration migration)
        {
            using var unitOfWork = _unitOfWorkFactory.Create();

            foreach (var script in migration.MigrationScripts)
                unitOfWork.ScriptExecutor.Execute(script.ScriptCommandText);

            var performedMigration = CreatePerformedMigration(migration);
            unitOfWork.PerformedMigrationsRepository.AddPerformedMigration(performedMigration);

            unitOfWork.Commit();
        }

        private static PerformedMigration CreatePerformedMigration(Migration.Domain.Migration migration)
        {
            var dbMigration = Migration.Domain.Migration.Create(
                            migration.Id,
                            migration.Name);
            var performedMigration = PerformedMigration.CreateNew(dbMigration);
            return performedMigration;
        }
    }
}
