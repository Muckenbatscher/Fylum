using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Migration.Domain.UnitOfWork
{
    public class UnitOfWorkTransaction
    {
        public UnitOfWorkTransaction(IDbConnection connection, IDbTransaction transaction)
        {
            Connection = connection;
            Transaction = transaction;
        }

        public IDbConnection Connection { get; private set; }
        public IDbTransaction Transaction { get; private set; }
    }
}
