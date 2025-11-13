namespace Fylum.Migrations.Application.MinimallyRequired
{
    public interface IMinimallyRequiredMigrationService
    {
        public void EnusreMinimallyRequiredMigrationsPerformed();
        public IEnumerable<Domain.Migration> GetMinimallyRequiredUnperformedMigrations();
    }
}
