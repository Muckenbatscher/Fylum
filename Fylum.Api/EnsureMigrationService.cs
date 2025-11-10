using Fylum.Migrations.Application.MinimallyRequired;

namespace Fylum.Api;

public class EnsureMigrationService
{
    private readonly IMinimallyRequiredMigrationService _minimallyRequiredMigrationService;

    public EnsureMigrationService(IMinimallyRequiredMigrationService minimallyRequiredMigrationService)
    {
        _minimallyRequiredMigrationService = minimallyRequiredMigrationService;
    }

    public void EnsureMinimallyRequiredMigrations()
        => _minimallyRequiredMigrationService.EnusreMinimallyRequiredMigrationsPerformed();
}
