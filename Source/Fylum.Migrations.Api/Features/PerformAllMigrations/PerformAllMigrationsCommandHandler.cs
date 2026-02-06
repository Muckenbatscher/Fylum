using Fylum.Core.Application.Mapping;
using Fylum.Core.Application.Results;
using Fylum.Migrations.Api.Common.Domain;
using Fylum.Migrations.Api.Common.Domain.Perform;
using Fylum.Migrations.SharedModels;

namespace Fylum.Migrations.Api.Features.PerformAllMigrations;

public class PerformAllMigrationsCommandHandler : IPerformAllMigrationsCommandHandler
{
    private readonly IPerformMigrationUnitOfWorkFactory _unitOfWorkFactory;
    private readonly IMigrationService _migrationService;
    private readonly IMapper<IEnumerable<Migration>, IEnumerable<MigrationDto>> _mapper;

    public PerformAllMigrationsCommandHandler(IPerformMigrationUnitOfWorkFactory unitOfWorkFactory,
        IMigrationService migrationService,
        IMapper<IEnumerable<Migration>, IEnumerable<MigrationDto>> mapper)
    {
        _unitOfWorkFactory = unitOfWorkFactory;
        _migrationService = migrationService;
        _mapper = mapper;
    }

    public Result<IEnumerable<MigrationDto>> Handle(PerformAllMigrationsCommand command)
    {
        var migrationsToPerform = _migrationService.GetUnperformedMigrations().ToList();

        var performedMigrations = new List<Migration>();
        using var unitOfWork = _unitOfWorkFactory.Create();
        foreach (var migration in migrationsToPerform)
        {
            var performed = unitOfWork.MigrationPerformingService.Perform(migration.ProvidedMigration);
            performedMigrations.Add(performed);
        }
        unitOfWork.Commit();

        return _mapper.Map(performedMigrations).ToList();
    }
}