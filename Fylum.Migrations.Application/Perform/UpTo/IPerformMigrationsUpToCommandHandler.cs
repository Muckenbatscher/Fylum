using Fylum.Application;

namespace Fylum.Migrations.Application.Perform.UpTo;

public interface IPerformMigrationsUpToCommandHandler : ICommandHandler<PerformMigrationsUpToCommand, PerformMigrationsUpToResult>
{
}
