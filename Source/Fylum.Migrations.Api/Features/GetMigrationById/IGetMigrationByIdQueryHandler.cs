using Fylum.Core.Application.Query;
using Fylum.Migrations.SharedModels;

namespace Fylum.Migrations.Api.Features.GetMigrationById;

public interface IGetMigrationByIdQueryHandler : IQueryHandler<GetMigrationByIdQuery, MigrationDto>
{
}
