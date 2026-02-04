using Fylum.Core.Application.Results;

namespace Fylum.Core.Application.Query;

public interface IQueryHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
    Result<TResult> Handle(TQuery query);
}
