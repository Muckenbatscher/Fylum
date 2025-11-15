using Fylum.Application;

namespace Fylum.Migrations.Application.Perform.MinimallyRequired;

public interface IPerformMinimallyRequiredMigrationsCommandHandler : ICommandHandler<PerformMinimallyRequiredMigrationsCommand, PerformMinimallyRequiredMigrationsResult>
{
}
