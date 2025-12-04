using System.ComponentModel;

namespace Fylum.Migrations.Winforms.MainWindow.MigrationScript;

public partial class MigrationScriptDisplay : UserControl
{
    public MigrationScriptDisplay()
    {
        InitializeComponent();
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public string ScriptText
    {
        get => LB_ScriptText.Text;
        set => LB_ScriptText.Text = value;
    }
}