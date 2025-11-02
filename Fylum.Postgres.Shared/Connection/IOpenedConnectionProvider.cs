using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Postgres.Shared.Connection
{
    public interface IOpenedConnectionProvider
    {
        IDbConnection GetOpenedConnection();
    }
}
