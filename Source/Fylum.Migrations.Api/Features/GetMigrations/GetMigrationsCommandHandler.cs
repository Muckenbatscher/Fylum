using Fylum.Core.Application.Mapping;
using Fylum.Core.Application.Results;
using Fylum.Migrations.Api.Common.Domain;
using Fylum.Migrations.SharedModels;

namespace Fylum.Migrations.Api.Features.GetMigrations;

public class GetMigrationsCommandHandler : IGetMigrationsCommandHandler
{
    private readonly IMigrationService _migrationService;
    private readonly IMapper<Migration, MigrationDto> _mapper;

    public GetMigrationsCommandHandler(IMigrationService migrationService,
        IMapper<Migration, MigrationDto> mapper)
    {
        _migrationService = migrationService;
        _mapper = mapper;
    }

    public Result<IEnumerable<MigrationDto>> Handle(GetMigrationsCommand command)
    {
        var migrations = _migrationService.GetMigrations();
        var migrationResults = migrations.Select(_mapper.Map).ToList();
        return migrationResults;
    }
}