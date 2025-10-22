namespace Fylum.PostgreSql.Migration
{
    partial class MigrationMainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            M2TWinForms.M2TDataGridViewCellStyle m2tDataGridViewCellStyle11 = new M2TWinForms.M2TDataGridViewCellStyle();
            M2TWinForms.M2TDataGridViewCellStyle m2tDataGridViewCellStyle12 = new M2TWinForms.M2TDataGridViewCellStyle();
            M2TWinForms.M2TDataGridViewCellStyle m2tDataGridViewCellStyle13 = new M2TWinForms.M2TDataGridViewCellStyle();
            M2TWinForms.M2TDataGridViewCellStyle m2tDataGridViewCellStyle14 = new M2TWinForms.M2TDataGridViewCellStyle();
            M2TWinForms.M2TDataGridViewCellStyle m2tDataGridViewCellStyle15 = new M2TWinForms.M2TDataGridViewCellStyle();
            DG_Migrations = new M2TWinForms.M2TDataGridView();
            CL_IsApplied = new DataGridViewImageColumn();
            CL_Name = new DataGridViewTextBoxColumn();
            CL_ScriptsCount = new DataGridViewTextBoxColumn();
            CL_AppliedTimestamp = new DataGridViewTextBoxColumn();
            TLP_Migrations = new TableLayoutPanel();
            BT_ApplyUntilSelected = new M2TWinForms.M2TButton();
            BT_ApplyAll = new M2TWinForms.M2TButton();
            PN_Migrations = new M2TWinForms.M2TPanel();
            TLP_Main = new TableLayoutPanel();
            PN_SelectedMigration = new M2TWinForms.M2TPanel();
            migrationScriptDisplay1 = new Fylum.PostgreSql.Migration.Winforms.MainWindow.MigrationScript.MigrationScriptDisplay();
            migrationScriptDisplay2 = new Fylum.PostgreSql.Migration.Winforms.MainWindow.MigrationScript.MigrationScriptDisplay();
            migrationScriptDisplay3 = new Fylum.PostgreSql.Migration.Winforms.MainWindow.MigrationScript.MigrationScriptDisplay();
            ((System.ComponentModel.ISupportInitialize)DG_Migrations).BeginInit();
            TLP_Migrations.SuspendLayout();
            PN_Migrations.SuspendLayout();
            TLP_Main.SuspendLayout();
            PN_SelectedMigration.SuspendLayout();
            SuspendLayout();
            // 
            // DG_Migrations
            // 
            DG_Migrations.AllowUserToAddRows = false;
            DG_Migrations.AllowUserToDeleteRows = false;
            DG_Migrations.AllowUserToResizeRows = false;
            m2tDataGridViewCellStyle11.ColorRole = M2TWinForms.M2TDataGridViewCellStyleColorRoleSelection.Empty;
            m2tDataGridViewCellStyle11.SelectionColorRole = M2TWinForms.M2TDataGridViewCellStyleColorRoleSelection.Empty;
            DG_Migrations.AlternatingRowsDefaultCellStyle = m2tDataGridViewCellStyle11;
            DG_Migrations.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DG_Migrations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DG_Migrations.BackgroundColorRole = M2TWinForms.M2TDataGridViewBackgroundColorSelection.SurfaceContainerHigh;
            m2tDataGridViewCellStyle12.ColorRole = M2TWinForms.M2TDataGridViewCellStyleColorRoleSelection.SurfaceContainerHigh;
            m2tDataGridViewCellStyle12.SelectionColorRole = M2TWinForms.M2TDataGridViewCellStyleColorRoleSelection.Empty;
            DG_Migrations.ColumnHeadersDefaultCellStyle = m2tDataGridViewCellStyle12;
            DG_Migrations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DG_Migrations.Columns.AddRange(new DataGridViewColumn[] { CL_IsApplied, CL_Name, CL_ScriptsCount, CL_AppliedTimestamp });
            TLP_Migrations.SetColumnSpan(DG_Migrations, 2);
            m2tDataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleLeft;
            m2tDataGridViewCellStyle13.Font = new Font("Segoe UI", 9F);
            m2tDataGridViewCellStyle13.SelectionColorRole = M2TWinForms.M2TDataGridViewCellStyleColorRoleSelection.PrimaryContainer;
            m2tDataGridViewCellStyle13.WrapMode = DataGridViewTriState.False;
            DG_Migrations.DefaultCellStyle = m2tDataGridViewCellStyle13;
            DG_Migrations.DefaultCellStyleSelectionColorRole = M2TWinForms.M2TDataGridViewCellStyleColorRoleSelection.PrimaryContainer;
            DG_Migrations.Location = new Point(3, 3);
            DG_Migrations.MultiSelect = false;
            DG_Migrations.Name = "DG_Migrations";
            DG_Migrations.ReadOnly = true;
            m2tDataGridViewCellStyle14.ColorRole = M2TWinForms.M2TDataGridViewCellStyleColorRoleSelection.SurfaceContainerHigh;
            m2tDataGridViewCellStyle14.SelectionColorRole = M2TWinForms.M2TDataGridViewCellStyleColorRoleSelection.Empty;
            DG_Migrations.RowHeadersDefaultCellStyle = m2tDataGridViewCellStyle14;
            DG_Migrations.RowHeadersVisible = false;
            m2tDataGridViewCellStyle15.ColorRole = M2TWinForms.M2TDataGridViewCellStyleColorRoleSelection.Empty;
            m2tDataGridViewCellStyle15.SelectionColorRole = M2TWinForms.M2TDataGridViewCellStyleColorRoleSelection.Empty;
            DG_Migrations.RowsDefaultCellStyle = m2tDataGridViewCellStyle15;
            DG_Migrations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DG_Migrations.Size = new Size(364, 322);
            DG_Migrations.TabIndex = 12;
            DG_Migrations.CellPainting += DG_Migrations_CellPainting;
            DG_Migrations.SelectionChanged += DG_Migrations_SelectionChanged;
            // 
            // CL_IsApplied
            // 
            CL_IsApplied.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            CL_IsApplied.HeaderText = "";
            CL_IsApplied.Name = "CL_IsApplied";
            CL_IsApplied.ReadOnly = true;
            CL_IsApplied.Width = 40;
            // 
            // CL_Name
            // 
            CL_Name.FillWeight = 150F;
            CL_Name.HeaderText = "Name";
            CL_Name.Name = "CL_Name";
            CL_Name.ReadOnly = true;
            // 
            // CL_ScriptsCount
            // 
            CL_ScriptsCount.FillWeight = 50F;
            CL_ScriptsCount.HeaderText = "Script Count";
            CL_ScriptsCount.Name = "CL_ScriptsCount";
            CL_ScriptsCount.ReadOnly = true;
            // 
            // CL_AppliedTimestamp
            // 
            CL_AppliedTimestamp.HeaderText = "Applied Timestamp";
            CL_AppliedTimestamp.Name = "CL_AppliedTimestamp";
            CL_AppliedTimestamp.ReadOnly = true;
            // 
            // TLP_Migrations
            // 
            TLP_Migrations.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TLP_Migrations.ColumnCount = 2;
            TLP_Migrations.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            TLP_Migrations.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            TLP_Migrations.Controls.Add(BT_ApplyUntilSelected, 0, 1);
            TLP_Migrations.Controls.Add(DG_Migrations, 0, 0);
            TLP_Migrations.Controls.Add(BT_ApplyAll, 1, 1);
            TLP_Migrations.Location = new Point(3, 3);
            TLP_Migrations.Name = "TLP_Migrations";
            TLP_Migrations.RowCount = 2;
            TLP_Migrations.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TLP_Migrations.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            TLP_Migrations.Size = new Size(370, 378);
            TLP_Migrations.TabIndex = 13;
            // 
            // BT_ApplyUntilSelected
            // 
            BT_ApplyUntilSelected.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BT_ApplyUntilSelected.ColorRole = M2TWinForms.M2TButtonColorRoleSelection.Tertiary;
            BT_ApplyUntilSelected.Location = new Point(3, 331);
            BT_ApplyUntilSelected.Name = "BT_ApplyUntilSelected";
            BT_ApplyUntilSelected.Size = new Size(179, 44);
            BT_ApplyUntilSelected.TabIndex = 14;
            BT_ApplyUntilSelected.Text = "Apply Until Selected";
            BT_ApplyUntilSelected.Click += BT_ApplyUntilSelected_Click;
            // 
            // BT_ApplyAll
            // 
            BT_ApplyAll.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BT_ApplyAll.ColorRole = M2TWinForms.M2TButtonColorRoleSelection.Primary;
            BT_ApplyAll.Location = new Point(188, 331);
            BT_ApplyAll.Name = "BT_ApplyAll";
            BT_ApplyAll.Size = new Size(179, 44);
            BT_ApplyAll.TabIndex = 13;
            BT_ApplyAll.Text = "Apply All";
            BT_ApplyAll.Click += BT_ApplyAll_Click;
            // 
            // PN_Migrations
            // 
            PN_Migrations.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PN_Migrations.ColorRole = M2TWinForms.M2TPanelColorRoleSelection.SurfaceContainer;
            PN_Migrations.Controls.Add(TLP_Migrations);
            PN_Migrations.Location = new Point(6, 6);
            PN_Migrations.Margin = new Padding(6);
            PN_Migrations.Name = "PN_Migrations";
            PN_Migrations.Size = new Size(376, 384);
            PN_Migrations.TabIndex = 14;
            // 
            // TLP_Main
            // 
            TLP_Main.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TLP_Main.ColumnCount = 2;
            TLP_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            TLP_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            TLP_Main.Controls.Add(PN_Migrations, 0, 0);
            TLP_Main.Controls.Add(PN_SelectedMigration, 1, 0);
            TLP_Main.Location = new Point(12, 42);
            TLP_Main.Name = "TLP_Main";
            TLP_Main.RowCount = 1;
            TLP_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TLP_Main.Size = new Size(776, 396);
            TLP_Main.TabIndex = 15;
            // 
            // PN_SelectedMigration
            // 
            PN_SelectedMigration.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PN_SelectedMigration.ColorRole = M2TWinForms.M2TPanelColorRoleSelection.SurfaceContainer;
            PN_SelectedMigration.Controls.Add(migrationScriptDisplay3);
            PN_SelectedMigration.Controls.Add(migrationScriptDisplay2);
            PN_SelectedMigration.Controls.Add(migrationScriptDisplay1);
            PN_SelectedMigration.Location = new Point(394, 6);
            PN_SelectedMigration.Margin = new Padding(6);
            PN_SelectedMigration.Name = "PN_SelectedMigration";
            PN_SelectedMigration.Size = new Size(376, 384);
            PN_SelectedMigration.TabIndex = 16;
            // 
            // migrationScriptDisplay1
            // 
            migrationScriptDisplay1.AutoSize = true;
            migrationScriptDisplay1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            migrationScriptDisplay1.Dock = DockStyle.Top;
            migrationScriptDisplay1.Location = new Point(0, 0);
            migrationScriptDisplay1.Margin = new Padding(5);
            migrationScriptDisplay1.Name = "migrationScriptDisplay1";
            migrationScriptDisplay1.Padding = new Padding(5);
            migrationScriptDisplay1.ScriptText = "m2tLabel5656";
            migrationScriptDisplay1.Size = new Size(376, 155);
            migrationScriptDisplay1.TabIndex = 0;
            // 
            // migrationScriptDisplay2
            // 
            migrationScriptDisplay2.AutoSize = true;
            migrationScriptDisplay2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            migrationScriptDisplay2.Dock = DockStyle.Top;
            migrationScriptDisplay2.Location = new Point(0, 155);
            migrationScriptDisplay2.Margin = new Padding(5);
            migrationScriptDisplay2.Name = "migrationScriptDisplay2";
            migrationScriptDisplay2.Padding = new Padding(5);
            migrationScriptDisplay2.ScriptText = "m2tLabel1212";
            migrationScriptDisplay2.Size = new Size(376, 155);
            migrationScriptDisplay2.TabIndex = 1;
            // 
            // migrationScriptDisplay3
            // 
            migrationScriptDisplay3.AutoSize = true;
            migrationScriptDisplay3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            migrationScriptDisplay3.Dock = DockStyle.Top;
            migrationScriptDisplay3.Location = new Point(0, 310);
            migrationScriptDisplay3.Margin = new Padding(5);
            migrationScriptDisplay3.Name = "migrationScriptDisplay3";
            migrationScriptDisplay3.Padding = new Padding(5);
            migrationScriptDisplay3.ScriptText = "m2tLabel1";
            migrationScriptDisplay3.Size = new Size(376, 155);
            migrationScriptDisplay3.TabIndex = 2;
            // 
            // MigrationMainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(TLP_Main);
            Name = "MigrationMainWindow";
            Text = "Migrations";
            WindowIcon = Winforms.Properties.Resources.MigrateIcon;
            Load += MigrationMainWindow_Load;
            Controls.SetChildIndex(TLP_Main, 0);
            ((System.ComponentModel.ISupportInitialize)DG_Migrations).EndInit();
            TLP_Migrations.ResumeLayout(false);
            PN_Migrations.ResumeLayout(false);
            TLP_Main.ResumeLayout(false);
            PN_SelectedMigration.ResumeLayout(false);
            PN_SelectedMigration.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private M2TWinForms.M2TDataGridView DG_Migrations;
        private DataGridViewImageColumn CL_IsApplied;
        private DataGridViewTextBoxColumn CL_Name;
        private DataGridViewTextBoxColumn CL_ScriptsCount;
        private DataGridViewTextBoxColumn CL_AppliedTimestamp;
        private TableLayoutPanel TLP_Migrations;
        private M2TWinForms.M2TButton BT_ApplyAll;
        private M2TWinForms.M2TButton BT_ApplyUntilSelected;
        private M2TWinForms.M2TPanel PN_Migrations;
        private TableLayoutPanel TLP_Main;
        private M2TWinForms.M2TPanel PN_SelectedMigration;
        private Winforms.MainWindow.MigrationScript.MigrationScriptDisplay migrationScriptDisplay1;
        private Winforms.MainWindow.MigrationScript.MigrationScriptDisplay migrationScriptDisplay2;
        private Winforms.MainWindow.MigrationScript.MigrationScriptDisplay migrationScriptDisplay3;
    }
}
