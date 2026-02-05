using Fylum.Core.Application.Query;
using Fylum.Migrations.SharedModels;

namespace Fylum.Migrations.Api.Features.GetMigrations;

public interface IGetMigrationsQueryHandler : IQueryHandler<GetMigrationsQuery, IEnumerable<MigrationDto>>
{
}