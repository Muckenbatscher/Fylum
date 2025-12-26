using System.Data;

namespace Fylum.Domain.UnitOfWork;

public record UnitOfWorkTransaction(IDbConnection Connection, IDbTransaction Transaction);