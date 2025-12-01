using Fylum.Application;
using Fylum.Migrations.Domain;

namespace Fylum.Migrations.Application.GetMigrations;

public class GetMigrationCommandHandler : IGetMigrationCommandHandler
{
    private readonly IMigrationService _migrationService;

    public GetMigrationCommandHandler(IMigrationService migrationService)
    {
        _migrationService = migrationService;
    }

    public Result<GetMigrationCommandResult> Handle(GetMigrationCommand command)
    {
        var migration = _migrationService.GetMigration(command.MigrationId);
        if (migration == null)
            return Result.Failure(Error.NotFound);

        return MapToResponse(migration);
    }

    private GetMigrationCommandResult MapToResponse(Migration m)
        => new GetMigrationCommandResult(m.ProvidedMigration.Id,
            m.ProvidedMigration.Name,
            m.IsPerformed);
}
