using Fylum.Application;
using Fylum.Migrations.Application.WithAppliedState;
using Fylum.Users.Domain.Groups;

namespace Fylum.Migrations.Application.GetMigrations;

public class GetAllMigrationsCommandHandler : IGetAllMigrationsCommandHandler
{
    private readonly IMigrationWithAppliedStateService _migrationService;
    private readonly IUserWithGroupsRepository _userRepo;

    public GetAllMigrationsCommandHandler(IMigrationWithAppliedStateService migrationService,
        IUserWithGroupsRepository userRepo)
    {
        _migrationService = migrationService;
        _userRepo = userRepo;
    }

    public Result<IEnumerable<GetMigrationCommandResult>> Handle(GetAllMigrationsCommand command)
    {
        var user = _userRepo.GetByUserId(command.UserId);
        if (user is null)
            return Result.Failure(Error.Unauthorized);
        var isAdmin = user.Groups.Any(g => g.IsAdmin);
        if (!isAdmin)
            return Result.Failure(Error.Unauthorized);

        var migrations = _migrationService.GetMigrationsWithAppliedState();
        var migrationResults = migrations.Select(MapToResult).ToList();
        return migrationResults;
    }


    private GetMigrationCommandResult MapToResult(MigrationWithAppliedState m)
        => new GetMigrationCommandResult(m.Migration.Id,
            m.Migration.Name,
            m.IsApplied,
            m.Migration.IsMinimallyRequired);
}
