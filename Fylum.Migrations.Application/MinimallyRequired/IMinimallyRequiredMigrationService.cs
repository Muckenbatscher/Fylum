namespace Fylum.Migrations.Application.MinimallyRequired
{
    public interface IMinimallyRequiredMigrationService
    {
        public void EnusreMinimallyRequiredMigrationsApplied();
        public IEnumerable<Domain.Migration> GetMinimallyRequiredUnappliedMigrations();
    }
}
