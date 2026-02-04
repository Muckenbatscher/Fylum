using Fylum.Core.Application.Command;
using Fylum.Migrations.SharedModels;

namespace Fylum.Migrations.Api.Features.PerformUpTo;

public interface IPerformMigrationsUpToCommandHandler : ICommandHandler<PerformMigrationsUpToCommand, IEnumerable<MigrationDto>>
{
}