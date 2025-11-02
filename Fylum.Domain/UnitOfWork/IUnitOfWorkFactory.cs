using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Domain.UnitOfWork
{
    public interface IUnitOfWorkFactory<TUnitOfWork> : IDisposable
        where TUnitOfWork : IUnitOfWork
    {
        TUnitOfWork Create();
    }
}
