using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.PostgreSql.Migration.Domain.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IUnitOfWorkTransactionFactory _transactionFactory;

        public UnitOfWork(IUnitOfWorkTransactionFactory transactionFactory)
        {
            _transactionFactory = transactionFactory;
        }

        public void Commit()
        {
            var transaction = _transactionFactory.GetTransaction();
            transaction.Transaction.Commit();
        }

        public void Rollback()
        {
            var transaction = _transactionFactory.GetTransaction();
            transaction.Transaction.Rollback();
        }

        public void Dispose()
        {
            var transaction = _transactionFactory.GetTransaction();
            transaction.Transaction.Dispose();
            transaction.Connection.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
