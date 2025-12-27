namespace Fylum.Application;

public interface IQueryHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
    Result<TResult> Handle(TQuery query);
}
