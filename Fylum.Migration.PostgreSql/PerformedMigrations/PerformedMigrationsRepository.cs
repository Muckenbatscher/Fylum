using Dapper;
using Fylum.Migration.Domain.PerformedMigrations;
using Fylum.Migration.Domain.UnitOfWork;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Migration.PostgreSql.PerformedMigrations
{
    public class PerformedMigrationsRepository : IPerformedMigrationsRepository
    {
        private const string TableDoesNotExistState = "42P01";

        private readonly IUnitOfWorkTransactionFactory _transactionFactory;
        public PerformedMigrationsRepository(IUnitOfWorkTransactionFactory transactionFactory)
        {
            _transactionFactory = transactionFactory;
        }

        public void AddPerformedMigration(PerformedMigration performedMigration)
        {
            InsertMigration(performedMigration.Migration);
            InsertPerformedMigration(performedMigration);
        }
        private void InsertMigration(Domain.Migration migration)
        {
            var param = new
            {
                id = migration.Id,
                name = migration.Name
            };
            string sql = @$"INSERT INTO migrations
                            (id, name)
                            VALUES (@{nameof(param.id)}, @{nameof(param.name)})";
            var transaction = _transactionFactory.GetTransaction();
            var connection = transaction.Connection;
            connection.Execute(sql,
                param: param,
                transaction: transaction.Transaction);
        }
        private void InsertPerformedMigration(PerformedMigration performedMigration)
        {
            var param = new
            {
                id = performedMigration.Id,
                timestamp = performedMigration.Timestamp,
                migrationId = performedMigration.Migration.Id
            };
            string sql = @$"INSERT INTO migrations_performed
                            (id, time_stamp, migration_id)
                            VALUES (@{nameof(param.id)}, @{nameof(param.timestamp)}, @{nameof(param.migrationId)})";
            var transaction = _transactionFactory.GetTransaction();
            var connection = transaction.Connection;
            connection.Execute(sql,
                param: param,
                transaction: transaction.Transaction);
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
                var transaction = _transactionFactory.GetTransaction();
                transaction.Connection.Dispose();
                if (pgEx.SqlState == TableDoesNotExistState)
                    return [];
                else
                    throw;
            }
        }

        private IEnumerable<PerformedMigrationQueryModel> QueryPerformedMigrations()
        {
            string sql = @$"SELECT mp.id AS {nameof(PerformedMigrationQueryModel.Id)},
                                   mp.time_stamp AS {nameof(PerformedMigrationQueryModel.Timestamp)},
                                   mp.migration_id AS {nameof(PerformedMigrationQueryModel.MigrationId)},    
                                   m.name AS {nameof(PerformedMigrationQueryModel.MigratioName)}
                            FROM migrations_performed mp 
                            JOIN migrations m
                              ON mp.migration_id = m.id
                            ORDER BY mp.time_stamp DESC;";
            var transaction = _transactionFactory.GetTransaction();
            var connection = transaction.Connection;
            return connection.Query<PerformedMigrationQueryModel>(sql, 
                transaction: transaction.Transaction);
        }

        private PerformedMigration MapToDomain(PerformedMigrationQueryModel queryModel)
        {
            var migration = Domain.Migration.Create(
                queryModel.MigrationId, 
                queryModel.MigratioName);
            return PerformedMigration.Create(
                queryModel.Id,
                queryModel.Timestamp,
                migration);
        }
    }
}
