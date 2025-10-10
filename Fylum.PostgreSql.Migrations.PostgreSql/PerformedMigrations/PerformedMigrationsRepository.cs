using Dapper;
using Fylum.PostgreSql.Migration.Domain.PerformedMigrations;
using Fylum.PostgreSql.Shared.Connection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.PostgreSql.Migrations.PostgreSql.PerformedMigrations
{
    public class PerformedMigrationsRepository : IPerformedMigrationsRepository
    {
        private const string TableDoesNotExistState = "42P01";

        private readonly IOpenedConnectionProvider _openedConnectionProvider;

        public PerformedMigrationsRepository(IOpenedConnectionProvider openedConnectionProvider)
        {
            _openedConnectionProvider = openedConnectionProvider;
        }

        public void AddPerformedMigration(PerformedMigration performedMigration)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PerformedMigration> GetPerformedMigrations()
        {
            try
            {
                var performed = QueryPerformedMigrations();
                return performed.Select(MapToDomain).ToList();
            }
            catch (PostgresException pgEx)
            {
                if (pgEx.SqlState == TableDoesNotExistState)
                    return [];
                else
                    throw;
            }
        }

        private IEnumerable<PerformedMigrationQueryModel> QueryPerformedMigrations()
        {
            string sql = @$"SELECT mp.id AS {nameof(PerformedMigrationQueryModel.Id)},
                                   mp.timestamp AS {nameof(PerformedMigrationQueryModel.Timestamp)},
                                   mp.migration_id AS {nameof(PerformedMigrationQueryModel.MigrationId)},    
                                   m.name AS {nameof(PerformedMigrationQueryModel.MigratioName)}
                            FROM migrations_performed mp 
                            JOIN migrations m
                              ON mp.migration_id = m.id
                            ORDER BY m.timestamp DESC;";
            using var connection = _openedConnectionProvider.GetOpenedConnection();
            return connection.Query<PerformedMigrationQueryModel>(sql);
        }

        private PerformedMigration MapToDomain(PerformedMigrationQueryModel queryModel)
        {
            var migration = Migration.Domain.PerformedMigrations.Migration.Create(
                queryModel.MigrationId, 
                queryModel.MigratioName);
            return PerformedMigration.Create(
                queryModel.Id,
                queryModel.Timestamp,
                migration);
        }
    }
}
