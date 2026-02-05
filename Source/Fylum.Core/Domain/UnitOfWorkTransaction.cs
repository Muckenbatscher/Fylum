using System.Data;

namespace Fylum.Core.Domain;

public record UnitOfWorkTransaction(IDbConnection Connection, IDbTransaction Transaction);