using Fylum.Application;
using Fylum.Migrations.Domain;
using Fylum.Users.Domain.Groups;

namespace Fylum.Migrations.Application.GetMigrations;

public class GetMigrationCommandHandler : IGetMigrationCommandHandler
{
    private readonly IMigrationService _migrationService;
    private readonly IUserWithGroupsRepository _userRepo;

    public GetMigrationCommandHandler(IMigrationService migrationService,
        IUserWithGroupsRepository userRepo)
    {
        _migrationService = migrationService;
        _userRepo = userRepo;
    }

    public Result<GetMigrationCommandResult> Handle(GetMigrationCommand command)
    {
        var user = _userRepo.GetByUserId(command.UserId);
        if (user is null)
            return Result.Failure(Error.Unauthorized);
        var isAdmin = user.Groups.Any(g => g.IsAdmin);
        if (!isAdmin)
            return Result.Failure(Error.Unauthorized);

        var migration = _migrationService.GetMigration(command.MigrationId);
        if (migration == null)
            return Result.Failure(Error.NotFound);

        return MapToResponse(migration);
    }

    private GetMigrationCommandResult MapToResponse(Migration m)
        => new GetMigrationCommandResult(m.ProvidedMigration.Id,
            m.ProvidedMigration.Name,
            m.IsPerformed,
            m.ProvidedMigration.IsMinimallyRequired);
}
