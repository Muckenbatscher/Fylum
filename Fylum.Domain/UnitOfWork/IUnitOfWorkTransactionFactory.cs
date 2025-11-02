using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Domain.UnitOfWork
{
    public interface IUnitOfWorkTransactionFactory : IDisposable
    {
        UnitOfWorkTransaction GetTransaction();
    }
}
