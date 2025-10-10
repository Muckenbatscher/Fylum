using Fylum.PostgreSql.Migration.Application;
using Fylum.PostgreSql.Migration.Domain;
using Fylum.PostgreSql.Migration.Domain.PerformedMigrations;
using M2TWinForms;

namespace Fylum.PostgreSql.Migration
{
    public partial class MigrationMainWindow : M2TForm
    {
        private readonly IMigrationService _migrationService;

        public MigrationMainWindow(IMigrationService migrationService)
        {
            InitializeComponent();

            _migrationService = migrationService;
        }

        private void MigrationMainWindow_Load(object sender, EventArgs e)
        {
            var b = _migrationService.GetMigrationsWithAppliedState().ToArray();
        }
    }
}
