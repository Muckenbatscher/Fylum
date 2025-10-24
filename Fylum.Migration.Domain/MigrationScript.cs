using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Migration.Domain
{
    public class MigrationScript
    {
        public MigrationScript(string scriptCommandText)
        {
            ScriptCommandText = scriptCommandText;
        }

        public string ScriptCommandText { get; }
    }
}
