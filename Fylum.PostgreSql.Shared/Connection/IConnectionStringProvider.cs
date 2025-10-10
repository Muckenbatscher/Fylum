using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.PostgreSql.Shared.Connection
{
    public interface IConnectionStringProvider
    {
        string GetConnectionString();
    }
}
