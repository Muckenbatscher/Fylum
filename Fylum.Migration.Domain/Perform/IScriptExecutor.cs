using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Migration.Domain.Perform
{
    public interface IScriptExecutor
    {
        void Execute(string script);
    }
}
