using Fylum.Migration.Domain;
using Fylum.Migration.Winforms.MainWindow;
using Fylum.Migration.Winforms.MainWindow.MigrationScript;
using M2TWinForms;

namespace Fylum.Migration.Winforms.MainWindow
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

        private void DG_Migrations_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex != CL_IsApplied.Index || e.RowIndex < 0)
                return;

            var datagrid = (DataGridView)sender;
            var row = datagrid.Rows[e.RowIndex];
            var migration = (MigrationRow)row.DataBoundItem;
            var image = migration.IsApplied
                ? Fylum.Migration.Winforms.Properties.Resources.VerifiedIcon
                : new Bitmap(1, 1);

            var backColor = row.Selected ? e.CellStyle.SelectionBackColor : e.CellStyle.BackColor;
            var foreColor = row.Selected ? e.CellStyle.SelectionForeColor : e.CellStyle.ForeColor;
            var rectWithoutBorder = new Rectangle(new Point(e.CellBounds.X + 1, e.CellBounds.Y), new Size(e.CellBounds.Width - 2, e.CellBounds.Height - 1));

            e.Graphics.PrepareGraphicsForHighQualityDrawing();
            e.Graphics.FillRectangle(new SolidBrush(backColor), rectWithoutBorder);
            e.Graphics.DrawImageWithColor(image, foreColor, rectWithoutBorder);
            e.Handled = true;
        }

        private void DG_Migrations_SelectionChanged(object sender, EventArgs e)
        {
            ClearCurrentSelectedMigrationDisplay();
            if (SelectedMigration == null)
                return;

            LB_SelectedMigrationName.Text = SelectedMigration.Name;
            bool applied = SelectedMigration.IsApplied;
            LB_SelectedMigrationTimestamp.Text = applied ? 
                SelectedMigration.LocalAppliedTimestamp?.ToString("G") :
                string.Empty;

            var image = applied
                ? Winforms.Properties.Resources.VerifiedIcon
                : new Bitmap(1, 1);
            CIB_SelectedMigrationAppliedState.BaseImage = image;

            foreach (var script in SelectedMigration.Migration.MigrationScripts.Reverse())
            {
                var scriptDisplay = new MigrationScriptDisplay
                {
                    ScriptText = script.ScriptCommandText,
                    Dock = DockStyle.Top,
                    Padding = new Padding(3)
                };
                FLP_SelectedMigrationScripts.Controls.Add(scriptDisplay);
            }
        }

        private void ClearCurrentSelectedMigrationDisplay()
        {
            LB_SelectedMigrationName.Text = "";
            LB_SelectedMigrationTimestamp.Text = "";
            FLP_SelectedMigrationScripts.Controls.Clear();
            CIB_SelectedMigrationAppliedState.BaseImage = new Bitmap(1, 1);
        }
    }
}
