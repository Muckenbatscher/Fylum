using Fylum.Application;
using Fylum.Migrations.Application.WithAppliedState;
using Fylum.Users.Domain.Groups;

namespace Fylum.Migrations.Application.GetMigrations;

public class GetMigrationCommandHandler : IGetMigrationCommandHandler
{
    private readonly IMigrationWithAppliedStateService _migrationService;
    private readonly IUserWithGroupsRepository _userRepo;

    public GetMigrationCommandHandler(IMigrationWithAppliedStateService migrationService,
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

        var migration = _migrationService.GetMigrationWithAppliedState(command.MigrationId);
        if (migration == null)
            return Result.Failure(Error.NotFound);

        return MapToResponse(migration);
    }

    private GetMigrationCommandResult MapToResponse(MigrationWithAppliedState m)
        => new GetMigrationCommandResult(m.Migration.Id,
            m.Migration.Name,
            m.IsApplied,
            m.Migration.IsMinimallyRequired);
}
