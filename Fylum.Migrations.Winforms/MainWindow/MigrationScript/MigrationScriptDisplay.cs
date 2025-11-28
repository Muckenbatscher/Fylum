using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fylum.Migrations.Winforms.MainWindow.MigrationScript
{
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
}
