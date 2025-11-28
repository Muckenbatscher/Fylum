using Fylum.Application;

namespace Fylum.Migrations.Application.Perform.All;

public interface IPerformAllMigrationsCommandHandler : ICommandHandler<PerformAllMigrationsCommand, PerformAllMigrationsResult>
{
}