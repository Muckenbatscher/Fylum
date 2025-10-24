using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.PostgreSql.Connection
{
    public interface IConnectionProvider
    {
        IDbConnection CreateConnection();
    }
}
