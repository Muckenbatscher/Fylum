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
            M2TWinForms.M2TDataGridViewCellStyle m2tDataGridViewCellStyle1 = new M2TWinForms.M2TDataGridViewCellStyle();
            M2TWinForms.M2TDataGridViewCellStyle m2tDataGridViewCellStyle2 = new M2TWinForms.M2TDataGridViewCellStyle();
            M2TWinForms.M2TDataGridViewCellStyle m2tDataGridViewCellStyle3 = new M2TWinForms.M2TDataGridViewCellStyle();
            M2TWinForms.M2TDataGridViewCellStyle m2tDataGridViewCellStyle4 = new M2TWinForms.M2TDataGridViewCellStyle();
            M2TWinForms.M2TDataGridViewCellStyle m2tDataGridViewCellStyle5 = new M2TWinForms.M2TDataGridViewCellStyle();
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
            TLP_SelectedMigration = new TableLayoutPanel();
            FLP_SelectedMigrationScripts = new FlowLayoutPanel();
            LB_SelectedMigrationName = new M2TWinForms.M2TLabel();
            LB_SelectedMigrationTimestamp = new M2TWinForms.M2TLabel();
            CIB_SelectedMigrationAppliedState = new M2TWinForms.M2TColoredImageButton();
            ((System.ComponentModel.ISupportInitialize)DG_Migrations).BeginInit();
            TLP_Migrations.SuspendLayout();
            PN_Migrations.SuspendLayout();
            TLP_Main.SuspendLayout();
            PN_SelectedMigration.SuspendLayout();
            TLP_SelectedMigration.SuspendLayout();
            SuspendLayout();
            // 
            // DG_Migrations
            // 
            DG_Migrations.AllowUserToAddRows = false;
            DG_Migrations.AllowUserToDeleteRows = false;
            DG_Migrations.AllowUserToResizeRows = false;
            m2tDataGridViewCellStyle1.ColorRole = M2TWinForms.M2TDataGridViewCellStyleColorRoleSelection.Empty;
            m2tDataGridViewCellStyle1.SelectionColorRole = M2TWinForms.M2TDataGridViewCellStyleColorRoleSelection.Empty;
            DG_Migrations.AlternatingRowsDefaultCellStyle = m2tDataGridViewCellStyle1;
            DG_Migrations.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DG_Migrations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DG_Migrations.BackgroundColorRole = M2TWinForms.M2TDataGridViewBackgroundColorSelection.SurfaceContainerHigh;
            m2tDataGridViewCellStyle2.ColorRole = M2TWinForms.M2TDataGridViewCellStyleColorRoleSelection.SurfaceContainerHigh;
            m2tDataGridViewCellStyle2.SelectionColorRole = M2TWinForms.M2TDataGridViewCellStyleColorRoleSelection.Empty;
            DG_Migrations.ColumnHeadersDefaultCellStyle = m2tDataGridViewCellStyle2;
            DG_Migrations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DG_Migrations.Columns.AddRange(new DataGridViewColumn[] { CL_IsApplied, CL_Name, CL_ScriptsCount, CL_AppliedTimestamp });
            TLP_Migrations.SetColumnSpan(DG_Migrations, 2);
            m2tDataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            m2tDataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            m2tDataGridViewCellStyle3.SelectionColorRole = M2TWinForms.M2TDataGridViewCellStyleColorRoleSelection.PrimaryContainer;
            m2tDataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            DG_Migrations.DefaultCellStyle = m2tDataGridViewCellStyle3;
            DG_Migrations.DefaultCellStyleSelectionColorRole = M2TWinForms.M2TDataGridViewCellStyleColorRoleSelection.PrimaryContainer;
            DG_Migrations.Location = new Point(3, 3);
            DG_Migrations.MultiSelect = false;
            DG_Migrations.Name = "DG_Migrations";
            DG_Migrations.ReadOnly = true;
            m2tDataGridViewCellStyle4.ColorRole = M2TWinForms.M2TDataGridViewCellStyleColorRoleSelection.SurfaceContainerHigh;
            m2tDataGridViewCellStyle4.SelectionColorRole = M2TWinForms.M2TDataGridViewCellStyleColorRoleSelection.Empty;
            DG_Migrations.RowHeadersDefaultCellStyle = m2tDataGridViewCellStyle4;
            DG_Migrations.RowHeadersVisible = false;
            m2tDataGridViewCellStyle5.ColorRole = M2TWinForms.M2TDataGridViewCellStyleColorRoleSelection.Empty;
            m2tDataGridViewCellStyle5.SelectionColorRole = M2TWinForms.M2TDataGridViewCellStyleColorRoleSelection.Empty;
            DG_Migrations.RowsDefaultCellStyle = m2tDataGridViewCellStyle5;
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
            PN_SelectedMigration.Controls.Add(TLP_SelectedMigration);
            PN_SelectedMigration.Location = new Point(394, 6);
            PN_SelectedMigration.Margin = new Padding(6);
            PN_SelectedMigration.Name = "PN_SelectedMigration";
            PN_SelectedMigration.Size = new Size(376, 384);
            PN_SelectedMigration.TabIndex = 16;
            // 
            // TLP_SelectedMigration
            // 
            TLP_SelectedMigration.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TLP_SelectedMigration.ColumnCount = 2;
            TLP_SelectedMigration.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TLP_SelectedMigration.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            TLP_SelectedMigration.Controls.Add(FLP_SelectedMigrationScripts, 0, 2);
            TLP_SelectedMigration.Controls.Add(LB_SelectedMigrationName, 0, 0);
            TLP_SelectedMigration.Controls.Add(LB_SelectedMigrationTimestamp, 0, 1);
            TLP_SelectedMigration.Controls.Add(CIB_SelectedMigrationAppliedState, 1, 0);
            TLP_SelectedMigration.Location = new Point(3, 3);
            TLP_SelectedMigration.Name = "TLP_SelectedMigration";
            TLP_SelectedMigration.RowCount = 3;
            TLP_SelectedMigration.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            TLP_SelectedMigration.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            TLP_SelectedMigration.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TLP_SelectedMigration.Size = new Size(370, 378);
            TLP_SelectedMigration.TabIndex = 0;
            // 
            // FLP_SelectedMigrationScripts
            // 
            FLP_SelectedMigrationScripts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            FLP_SelectedMigrationScripts.AutoScroll = true;
            TLP_SelectedMigration.SetColumnSpan(FLP_SelectedMigrationScripts, 2);
            FLP_SelectedMigrationScripts.Location = new Point(3, 53);
            FLP_SelectedMigrationScripts.Name = "FLP_SelectedMigrationScripts";
            FLP_SelectedMigrationScripts.Size = new Size(364, 322);
            FLP_SelectedMigrationScripts.TabIndex = 0;
            // 
            // LB_SelectedMigrationName
            // 
            LB_SelectedMigrationName.Anchor = AnchorStyles.Left;
            LB_SelectedMigrationName.AutoSize = true;
            LB_SelectedMigrationName.Font = new Font("Segoe UI", 12F);
            LB_SelectedMigrationName.Location = new Point(3, 2);
            LB_SelectedMigrationName.Name = "LB_SelectedMigrationName";
            LB_SelectedMigrationName.Size = new Size(124, 21);
            LB_SelectedMigrationName.TabIndex = 1;
            LB_SelectedMigrationName.Text = "Migration Name";
            // 
            // LB_SelectedMigrationTimestamp
            // 
            LB_SelectedMigrationTimestamp.Anchor = AnchorStyles.Left;
            LB_SelectedMigrationTimestamp.AutoSize = true;
            LB_SelectedMigrationTimestamp.ForeColorRole = M2TWinForms.M2TLabelTextColorRoleSelection.OnSurfaceVariant;
            LB_SelectedMigrationTimestamp.Location = new Point(3, 30);
            LB_SelectedMigrationTimestamp.Name = "LB_SelectedMigrationTimestamp";
            LB_SelectedMigrationTimestamp.Size = new Size(122, 15);
            LB_SelectedMigrationTimestamp.TabIndex = 2;
            LB_SelectedMigrationTimestamp.Text = "Migration Timestamp";
            // 
            // CIB_SelectedMigrationAppliedState
            // 
            CIB_SelectedMigrationAppliedState.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CIB_SelectedMigrationAppliedState.BackColor = Color.FromArgb(29, 32, 28);
            CIB_SelectedMigrationAppliedState.BackgroundColorRole = M2TWinForms.Themes.MaterialDesign.ColorRoles.SurfaceContainer;
            CIB_SelectedMigrationAppliedState.BaseImage = null;
            CIB_SelectedMigrationAppliedState.ConvertBaseImageToGrayscale = true;
            CIB_SelectedMigrationAppliedState.HoverBackColor = Color.FromArgb(29, 32, 28);
            CIB_SelectedMigrationAppliedState.HoverBackgroundColorRole = M2TWinForms.Themes.MaterialDesign.ColorRoles.SurfaceContainer;
            CIB_SelectedMigrationAppliedState.HoverEnabled = false;
            CIB_SelectedMigrationAppliedState.HoverImageColor = Color.FromArgb(226, 227, 219);
            CIB_SelectedMigrationAppliedState.HoverImageColorRole = M2TWinForms.Themes.MaterialDesign.ColorRoles.OnSurface;
            CIB_SelectedMigrationAppliedState.ImageColor = Color.FromArgb(170, 209, 155);
            CIB_SelectedMigrationAppliedState.ImageColorRole = M2TWinForms.Themes.MaterialDesign.ColorRoles.Primary;
            CIB_SelectedMigrationAppliedState.ImagePadding = new Padding(0);
            CIB_SelectedMigrationAppliedState.Location = new Point(323, 3);
            CIB_SelectedMigrationAppliedState.Name = "CIB_SelectedMigrationAppliedState";
            TLP_SelectedMigration.SetRowSpan(CIB_SelectedMigrationAppliedState, 2);
            CIB_SelectedMigrationAppliedState.Size = new Size(44, 44);
            CIB_SelectedMigrationAppliedState.TabIndex = 3;
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
            TLP_SelectedMigration.ResumeLayout(false);
            TLP_SelectedMigration.PerformLayout();
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
        private TableLayoutPanel TLP_SelectedMigration;
        private FlowLayoutPanel FLP_SelectedMigrationScripts;
        private M2TWinForms.M2TLabel LB_SelectedMigrationName;
        private M2TWinForms.M2TLabel LB_SelectedMigrationTimestamp;
        private M2TWinForms.M2TColoredImageButton CIB_SelectedMigrationAppliedState;
    }
}
