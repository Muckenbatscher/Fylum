using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.PostgreSql.Migration.PostgreSql.ScriptExecution
{
    public interface IScriptExecutor
    {
        void Execute(string script);
    }
}
