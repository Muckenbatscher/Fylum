using Fylum.Application;
using Fylum.Migrations.Domain;

namespace Fylum.Migrations.Application.GetMigrations;

public class GetAllMigrationsCommandHandler : IGetAllMigrationsCommandHandler
{
    private readonly IMigrationService _migrationService;

    public GetAllMigrationsCommandHandler(IMigrationService migrationService)
    {
        _migrationService = migrationService;
    }

    public Result<IEnumerable<GetMigrationCommandResult>> Handle(GetAllMigrationsCommand command)
    {
        var migrations = _migrationService.GetMigrations();
        var migrationResults = migrations.Select(MapToResult).ToList();
        return migrationResults;
    }

    private GetMigrationCommandResult MapToResult(Migration m)
        => new GetMigrationCommandResult(m.ProvidedMigration.Id,
            m.ProvidedMigration.Name,
            m.IsPerformed);
}
