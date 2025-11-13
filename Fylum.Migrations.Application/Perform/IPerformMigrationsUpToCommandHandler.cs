using Fylum.Application;

namespace Fylum.Migrations.Application.Perform;

public interface IPerformMigrationsUpToCommandHandler : ICommandHandler<PerformMigrationsUpToCommand, PerformMigrationsUpToResult>
{
}
