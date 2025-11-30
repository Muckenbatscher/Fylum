using Fylum.Application;
using Fylum.Migrations.Domain;
using Fylum.Users.Domain.Groups;

namespace Fylum.Migrations.Application.GetMigrations;

public class GetAllMigrationsCommandHandler : IGetAllMigrationsCommandHandler
{
    private readonly IMigrationService _migrationService;
    private readonly IUserWithGroupsRepository _userRepo;

    public GetAllMigrationsCommandHandler(IMigrationService migrationService,
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

        var migrations = _migrationService.GetMigrations();
        var migrationResults = migrations.Select(MapToResult).ToList();
        return migrationResults;
    }


    private GetMigrationCommandResult MapToResult(Migration m)
        => new GetMigrationCommandResult(m.ProvidedMigration.Id,
            m.ProvidedMigration.Name,
            m.IsPerformed,
            m.ProvidedMigration.IsMinimallyRequired);
}
