using Fylum.Core.Application.Mapping;
using Fylum.Core.Application.Results;
using Fylum.Migrations.Api.Common.Domain;
using Fylum.Migrations.SharedModels;

namespace Fylum.Migrations.Api.Features.GetMigrationById;

public class GetMigrationByIdQueryHandler : IGetMigrationByIdQueryHandler
{
    private readonly IMigrationService _migrationService;
    private readonly IMapper<Migration, MigrationDto> _mapper;

    public GetMigrationByIdQueryHandler(IMigrationService migrationService,
        IMapper<Migration, MigrationDto> mapper)
    {
        _migrationService = migrationService;
        _mapper = mapper;
    }

    public Result<MigrationDto> Handle(GetMigrationByIdQuery command)
    {
        var migration = _migrationService.GetMigration(command.MigrationId);
        if (migration == null)
            return Result.Failure(Error.NotFound);

        return _mapper.Map(migration);
    }
}