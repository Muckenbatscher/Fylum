using Fylum.Migrations.Winforms.MainWindow.MigrationScript;
using Fylum.Migrations.Winforms.MainWindow;
using M2TWinForms;
using System.ComponentModel;

namespace Fylum.Migrations.Winforms.MainWindow
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
            CL_PerformedTimestamp.DataPropertyName = nameof(MigrationRow.LocalPerformedTimestamp);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IEnumerable<MigrationRow> AllMigrations
        {
            get => (IEnumerable<MigrationRow>)DG_Migrations.DataSource;
            set => DG_Migrations.DataSource = value.ToList();
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MigrationRow? SelectedMigration
        {
            get
            {
                var selectedRows = DG_Migrations.SelectedRows.Cast<DataGridViewRow>();
                return selectedRows.FirstOrDefault()?.DataBoundItem as MigrationRow;
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool PerformUntilSelectedEnabled
        {
            get => BT_PerformUntilSelected.Enabled;
            set => BT_PerformUntilSelected.Enabled = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public EventHandler? ViewLoaded { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public EventHandler? PerformAllClicked { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public EventHandler? PerformUntilSelectedClicked { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public EventHandler? SelectedMigrationChanged { get; set; }

        public void UnselectAllMigrations()
            => DG_Migrations.ClearSelection();

        private void MigrationMainWindow_Load(object sender, EventArgs e)
            => ViewLoaded?.Invoke(this, e);

        private void BT_PerformAll_Click(object sender, EventArgs e)
            => PerformAllClicked?.Invoke(this, e);

        private void BT_PerformUntilSelected_Click(object sender, EventArgs e)
            => PerformUntilSelectedClicked?.Invoke(this, e);

        private void DG_Migrations_SelectionChanged(object sender, EventArgs e)
            => SelectedMigrationChanged?.Invoke(this, EventArgs.Empty);

        private void DG_Migrations_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex != CL_IsPerformed.Index || e.RowIndex < 0)
                return;
            if (e.Graphics == null)
                return;

            var datagrid = (DataGridView)sender;
            var row = datagrid.Rows[e.RowIndex];
            var migration = (MigrationRow)row.DataBoundItem;
            var image = migration.IsPerformed
                ? Properties.Resources.VerifiedIcon
                : new Bitmap(1, 1);

            var backColor = row.Selected ? e.CellStyle.SelectionBackColor : e.CellStyle.BackColor;
            var foreColor = row.Selected ? e.CellStyle.SelectionForeColor : e.CellStyle.ForeColor;
            var correctedRectPoint = new Point(e.CellBounds.X, e.CellBounds.Y - 1);
            var correctedRectSize = new Size(e.CellBounds.Width - 1, e.CellBounds.Height);
            var correctedRectangle = new Rectangle(correctedRectPoint, correctedRectSize);
            e.Graphics.FillRectangle(new SolidBrush(backColor), correctedRectangle); 
            e.Paint(e.CellBounds, DataGridViewPaintParts.Border);
            e.Graphics.PrepareGraphicsForHighQualityDrawing();
            e.Graphics.DrawImageWithColor(image, foreColor, correctedRectangle);
            e.Handled = true;
        }


        public void ClearSelectedMigrationDetails()
        {
            LB_SelectedMigrationName.Text = "";
            LB_SelectedMigrationTimestamp.Text = "";
            FLP_SelectedMigrationScripts.Controls.Clear();
            CIB_SelectedMigrationPerformedState.BaseImage = new Bitmap(1, 1);
        }

        public void DisplaySelectedMigrationDetails(MigrationRow migrationRow)
        {
            LB_SelectedMigrationName.Text = migrationRow.Name;
            bool performed = migrationRow.IsPerformed;
            LB_SelectedMigrationTimestamp.Text = performed ?
                migrationRow.LocalPerformedTimestamp?.ToString("G") :
                string.Empty;

            var image = performed
                ? Properties.Resources.VerifiedIcon
                : new Bitmap(1, 1);
            CIB_SelectedMigrationPerformedState.BaseImage = image;

            foreach (var script in migrationRow.Migration.MigrationScripts.Reverse())
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
    }
}
