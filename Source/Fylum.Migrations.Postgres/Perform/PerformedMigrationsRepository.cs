using Dapper;
using Fylum.Domain.UnitOfWork;
using Fylum.Migrations.Domain.Perform;
using Fylum.Migrations.Domain.Providing;
using Npgsql;

namespace Fylum.Migrations.Postgres.Perform;

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
    private void InsertMigration(ProvidedMigration migration)
    {
        var param = new
        {
            id = migration.Id,
            name = migration.Name
        };
        string sql = @$"INSERT INTO migration.migrations
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
        string sql = @$"INSERT INTO migration.migrations_performed
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
    public PerformedMigration? GetPerformedMigrationById(Guid id)
    {
        var performed = QueryPerformedMigrationById(id);
        if (performed == null)
            return null;

        return MapToDomain(performed);
    }

    private IEnumerable<PerformedMigrationQueryModel> QueryPerformedMigrations()
    {
        string sql = @$"SELECT mp.id AS {nameof(PerformedMigrationQueryModel.Id)},
                                   mp.time_stamp AS {nameof(PerformedMigrationQueryModel.Timestamp)},
                                   mp.migration_id AS {nameof(PerformedMigrationQueryModel.MigrationId)},    
                                   m.name AS {nameof(PerformedMigrationQueryModel.MigratioName)}
                            FROM migration.migrations_performed mp 
                            JOIN migration.migrations m
                              ON mp.migration_id = m.id
                            ORDER BY mp.time_stamp DESC;";
        var transaction = _transactionFactory.GetTransaction();
        var connection = transaction.Connection;
        return connection.Query<PerformedMigrationQueryModel>(sql,
            transaction: transaction.Transaction);
    }
    private PerformedMigrationQueryModel? QueryPerformedMigrationById(Guid id)
    {
        var param = new { id };
        string sql = @$"SELECT mp.id AS {nameof(PerformedMigrationQueryModel.Id)},
                                   mp.time_stamp AS {nameof(PerformedMigrationQueryModel.Timestamp)},
                                   mp.migration_id AS {nameof(PerformedMigrationQueryModel.MigrationId)},    
                                   m.name AS {nameof(PerformedMigrationQueryModel.MigratioName)}
                            FROM migration.migrations_performed mp 
                            JOIN migration.migrations m
                              ON mp.migration_id = m.id
                            WHERE m.id = @{nameof(param.id)};";
        var transaction = _transactionFactory.GetTransaction();
        var connection = transaction.Connection;
        return connection.QueryFirstOrDefault<PerformedMigrationQueryModel>(sql, param,
            transaction: transaction.Transaction);
    }

    private PerformedMigration MapToDomain(PerformedMigrationQueryModel queryModel)
    {
        var migration = ProvidedMigration.Create(
            queryModel.MigrationId,
            queryModel.MigratioName);
        return PerformedMigration.Create(
            queryModel.Id,
            queryModel.Timestamp,
            migration);
    }

}