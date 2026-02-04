using Fylum.Core.Application.Command;
using Fylum.Migrations.SharedModels;

namespace Fylum.Migrations.Api.Features.GetMigrations;

public interface IGetMigrationsCommandHandler : ICommandHandler<GetMigrationsCommand, IEnumerable<MigrationDto>>
{
}