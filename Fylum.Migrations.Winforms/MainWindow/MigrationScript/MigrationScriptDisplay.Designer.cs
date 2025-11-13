namespace Fylum.Migration.Winforms.MainWindow.MigrationScript
{
    partial class MigrationScriptDisplay
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PN_Background = new M2TWinForms.M2TPanel();
            LB_ScriptText = new M2TWinForms.M2TLabel();
            PN_Background.SuspendLayout();
            SuspendLayout();
            // 
            // PN_Background
            // 
            PN_Background.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PN_Background.AutoSize = true;
            PN_Background.ColorRole = M2TWinForms.M2TPanelColorRoleSelection.TertiaryContainer;
            PN_Background.Controls.Add(LB_ScriptText);
            PN_Background.Location = new Point(0, 0);
            PN_Background.Name = "PN_Background";
            PN_Background.Size = new Size(150, 150);
            PN_Background.TabIndex = 0;
            // 
            // LB_ScriptText
            // 
            LB_ScriptText.AutoSize = true;
            LB_ScriptText.Font = new Font("Courier New", 9F, FontStyle.Bold);
            LB_ScriptText.ForeColorRole = M2TWinForms.M2TLabelTextColorRoleSelection.OnTertiaryContainer;
            LB_ScriptText.Location = new Point(12, 11);
            LB_ScriptText.Name = "LB_ScriptText";
            LB_ScriptText.Size = new Size(70, 16);
            LB_ScriptText.TabIndex = 0;
            LB_ScriptText.Text = "m2tLabel1";
            // 
            // MigrationScriptDisplay
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(PN_Background);
            Name = "MigrationScriptDisplay";
            PN_Background.ResumeLayout(false);
            PN_Background.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private M2TWinForms.M2TPanel PN_Background;
        private M2TWinForms.M2TLabel LB_ScriptText;
    }
}
