using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Connection
{
    public interface IConnectionStringProvider
    {
        string GetConnectionString();
    }
}
