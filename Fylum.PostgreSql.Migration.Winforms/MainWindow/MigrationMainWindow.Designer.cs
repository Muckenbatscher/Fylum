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
            M2TWinForms.M2TDataGridViewCellStyle m2tDataGridViewCellStyle6 = new M2TWinForms.M2TDataGridViewCellStyle();
            M2TWinForms.M2TDataGridViewCellStyle m2tDataGridViewCellStyle7 = new M2TWinForms.M2TDataGridViewCellStyle();
            M2TWinForms.M2TDataGridViewCellStyle m2tDataGridViewCellStyle8 = new M2TWinForms.M2TDataGridViewCellStyle();
            M2TWinForms.M2TDataGridViewCellStyle m2tDataGridViewCellStyle9 = new M2TWinForms.M2TDataGridViewCellStyle();
            M2TWinForms.M2TDataGridViewCellStyle m2tDataGridViewCellStyle10 = new M2TWinForms.M2TDataGridViewCellStyle();
            DG_Migrations = new M2TWinForms.M2TDataGridView();
            CL_IsApplied = new DataGridViewImageColumn();
            CL_Name = new DataGridViewTextBoxColumn();
            CL_ScriptsCount = new DataGridViewTextBoxColumn();
            CL_AppliedTimestamp = new DataGridViewTextBoxColumn();
            TLP_Main = new TableLayoutPanel();
            BT_ApplyUntilSelected = new M2TWinForms.M2TButton();
            BT_ApplyAll = new M2TWinForms.M2TButton();
            ((System.ComponentModel.ISupportInitialize)DG_Migrations).BeginInit();
            TLP_Main.SuspendLayout();
            SuspendLayout();
            // 
            // DG_Migrations
            // 
            DG_Migrations.AllowUserToAddRows = false;
            DG_Migrations.AllowUserToDeleteRows = false;
            m2tDataGridViewCellStyle6.ColorRole = M2TWinForms.M2TDataGridViewCellStyleColorRoleSelection.Empty;
            m2tDataGridViewCellStyle6.SelectionColorRole = M2TWinForms.M2TDataGridViewCellStyleColorRoleSelection.Empty;
            DG_Migrations.AlternatingRowsDefaultCellStyle = m2tDataGridViewCellStyle6;
            DG_Migrations.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DG_Migrations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            m2tDataGridViewCellStyle7.ColorRole = M2TWinForms.M2TDataGridViewCellStyleColorRoleSelection.SurfaceContainerHigh;
            m2tDataGridViewCellStyle7.SelectionColorRole = M2TWinForms.M2TDataGridViewCellStyleColorRoleSelection.Empty;
            DG_Migrations.ColumnHeadersDefaultCellStyle = m2tDataGridViewCellStyle7;
            DG_Migrations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DG_Migrations.Columns.AddRange(new DataGridViewColumn[] { CL_IsApplied, CL_Name, CL_ScriptsCount, CL_AppliedTimestamp });
            TLP_Main.SetColumnSpan(DG_Migrations, 2);
            m2tDataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            m2tDataGridViewCellStyle8.Font = new Font("Segoe UI", 9F);
            m2tDataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            DG_Migrations.DefaultCellStyle = m2tDataGridViewCellStyle8;
            DG_Migrations.Location = new Point(3, 3);
            DG_Migrations.MultiSelect = false;
            DG_Migrations.Name = "DG_Migrations";
            DG_Migrations.ReadOnly = true;
            m2tDataGridViewCellStyle9.ColorRole = M2TWinForms.M2TDataGridViewCellStyleColorRoleSelection.SurfaceContainerHigh;
            m2tDataGridViewCellStyle9.SelectionColorRole = M2TWinForms.M2TDataGridViewCellStyleColorRoleSelection.Empty;
            DG_Migrations.RowHeadersDefaultCellStyle = m2tDataGridViewCellStyle9;
            DG_Migrations.RowHeadersVisible = false;
            m2tDataGridViewCellStyle10.ColorRole = M2TWinForms.M2TDataGridViewCellStyleColorRoleSelection.Empty;
            m2tDataGridViewCellStyle10.SelectionColorRole = M2TWinForms.M2TDataGridViewCellStyleColorRoleSelection.Empty;
            DG_Migrations.RowsDefaultCellStyle = m2tDataGridViewCellStyle10;
            DG_Migrations.Size = new Size(770, 340);
            DG_Migrations.TabIndex = 12;
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
            // TLP_Main
            // 
            TLP_Main.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TLP_Main.ColumnCount = 2;
            TLP_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            TLP_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            TLP_Main.Controls.Add(BT_ApplyUntilSelected, 0, 1);
            TLP_Main.Controls.Add(DG_Migrations, 0, 0);
            TLP_Main.Controls.Add(BT_ApplyAll, 1, 1);
            TLP_Main.Location = new Point(12, 42);
            TLP_Main.Name = "TLP_Main";
            TLP_Main.RowCount = 2;
            TLP_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TLP_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            TLP_Main.Size = new Size(776, 396);
            TLP_Main.TabIndex = 13;
            // 
            // BT_ApplyUntilSelected
            // 
            BT_ApplyUntilSelected.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BT_ApplyUntilSelected.ColorRole = M2TWinForms.M2TButtonColorRoleSelection.SurfaceContainerHigh;
            BT_ApplyUntilSelected.Location = new Point(3, 349);
            BT_ApplyUntilSelected.Name = "BT_ApplyUntilSelected";
            BT_ApplyUntilSelected.Size = new Size(382, 44);
            BT_ApplyUntilSelected.TabIndex = 14;
            BT_ApplyUntilSelected.Text = "Apply Until Selected";
            // 
            // BT_ApplyAll
            // 
            BT_ApplyAll.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BT_ApplyAll.ColorRole = M2TWinForms.M2TButtonColorRoleSelection.PrimaryContainer;
            BT_ApplyAll.Location = new Point(391, 349);
            BT_ApplyAll.Name = "BT_ApplyAll";
            BT_ApplyAll.Size = new Size(382, 44);
            BT_ApplyAll.TabIndex = 13;
            BT_ApplyAll.Text = "Apply All";
            // 
            // MigrationMainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(TLP_Main);
            Name = "MigrationMainWindow";
            Text = "Migrations";
            Load += MigrationMainWindow_Load;
            Controls.SetChildIndex(TLP_Main, 0);
            ((System.ComponentModel.ISupportInitialize)DG_Migrations).EndInit();
            TLP_Main.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private M2TWinForms.M2TDataGridView DG_Migrations;
        private DataGridViewImageColumn CL_IsApplied;
        private DataGridViewTextBoxColumn CL_Name;
        private DataGridViewTextBoxColumn CL_ScriptsCount;
        private DataGridViewTextBoxColumn CL_AppliedTimestamp;
        private TableLayoutPanel TLP_Main;
        private M2TWinForms.M2TButton BT_ApplyAll;
        private M2TWinForms.M2TButton BT_ApplyUntilSelected;
    }
}
