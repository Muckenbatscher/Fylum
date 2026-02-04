using Fylum.Application;
using Fylum.Core.Application.Mapping;
using Fylum.Migrations.Api.Common.Domain;
using Fylum.Migrations.Api.Common.Domain.Perform;
using Fylum.Migrations.SharedModels;

namespace Fylum.Migrations.Api.Features.PerformUpTo;

public class PerformMigrationsUpToCommandHandler : IPerformMigrationsUpToCommandHandler
{
    private readonly IPerformMigrationUnitOfWorkFactory _unitOfWorkFactory;
    private readonly IMigrationService _migrationService;
    private readonly IMapper<Migration, MigrationDto> _mapper;

    public PerformMigrationsUpToCommandHandler(IPerformMigrationUnitOfWorkFactory unitOfWorkFactory,
        IMigrationService migrationService,
        IMapper<Migration, MigrationDto> mapper)
    {
        _unitOfWorkFactory = unitOfWorkFactory;
        _migrationService = migrationService;
        _mapper = mapper;
    }

    public Result<IEnumerable<MigrationDto>> Handle(PerformMigrationsUpToCommand command)
    {
        var allMigrations = _migrationService.GetMigrations().ToList();
        var upToMigration = allMigrations.FirstOrDefault(m => m.ProvidedMigration.Id == command.UpToMigrationId);
        if (upToMigration == null)
            return Result.Failure(Error.NotFound);

        var upToMigrationIndex = allMigrations.IndexOf(upToMigration);
        if (upToMigration.IsPerformed)
        {
            var followingMigrations = allMigrations.Skip(upToMigrationIndex + 1);
            var anyFollowing = followingMigrations.Any();
            var anyFollowingAlreadyPerformed = followingMigrations.Any(m => m.IsPerformed);
            if (anyFollowing && anyFollowingAlreadyPerformed)
                return Result.Failure(Error.Validation);
            else
                return Result<IEnumerable<MigrationDto>>.Success([]);
        }

        var migrationsToPerform = allMigrations
            .Take(upToMigrationIndex + 1)
            .Where(m => !m.IsPerformed)
            .ToList();

        var performedMigrations = new List<Migration>();
        using var unitOfWork = _unitOfWorkFactory.Create();
        foreach (var migration in migrationsToPerform)
        {
            var performed = unitOfWork.MigrationPerformingService.Perform(migration.ProvidedMigration);
            performedMigrations.Add(performed);
        }
        unitOfWork.Commit();

        return performedMigrations.Select(_mapper.Map).ToList();
    }
}