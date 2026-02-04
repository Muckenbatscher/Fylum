using Fylum.Core.Application.Command;
using Fylum.Migrations.SharedModels;

namespace Fylum.Migrations.Api.Features.PerformAllMigrations;

public interface IPerformAllMigrationsCommandHandler : ICommandHandler<PerformAllMigrationsCommand, IEnumerable<MigrationDto>>
{
}