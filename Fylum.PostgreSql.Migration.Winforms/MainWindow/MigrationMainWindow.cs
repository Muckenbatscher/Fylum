using Fylum.PostgreSql.Migration.Winforms.MainWindow;
using M2TWinForms;

namespace Fylum.PostgreSql.Migration
{
    public partial class MigrationMainWindow : M2TForm, IMigrationMainWindow
    {
        public MigrationMainWindow()
        {
            InitializeComponent();
            InitializeDatabinding();
        }
        private void InitializeDatabinding()
        {
            DG_Migrations.AutoGenerateColumns = false;
            CL_Name.DataPropertyName = nameof(MigrationRow.Name);
            CL_ScriptsCount.DataPropertyName = nameof(MigrationRow.ScriptCount);
            CL_AppliedTimestamp.DataPropertyName = nameof(MigrationRow.LocalAppliedTimestamp);
        }

        public IEnumerable<MigrationRow> AllMigrations
        {
            get => (IEnumerable<MigrationRow>)DG_Migrations.DataSource;
            set => DG_Migrations.DataSource = value.ToList();
        }
        public MigrationRow? SelectedMigration
        {
            get
            {
                var selectedRows = DG_Migrations.SelectedRows.Cast<DataGridViewRow>();
                return selectedRows.FirstOrDefault()?.DataBoundItem as MigrationRow;
            }
        }

        public bool ApplyUntilSelectedEnabled
        {
            get => BT_ApplyUntilSelected.Enabled;
            set => BT_ApplyUntilSelected.Enabled = value;
        }

        public EventHandler? ViewLoaded { get; set; }
        public EventHandler? ApplyAllClicked { get; set; }
        public EventHandler? ApplyUntilSelectedClicked { get; set; }

        public void UnselectAllMigrations()
        {
            DG_Migrations.ClearSelection();
        }

        private void MigrationMainWindow_Load(object sender, EventArgs e)
            => ViewLoaded?.Invoke(this, e);

        private void BT_ApplyAll_Click(object sender, EventArgs e)
            => ApplyAllClicked?.Invoke(this, e);

        private void BT_ApplyUntilSelected_Click(object sender, EventArgs e)
            => ApplyUntilSelectedClicked?.Invoke(this, e);
    }
}
