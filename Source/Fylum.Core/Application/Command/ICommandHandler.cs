using Fylum.Core.Application.Results;

namespace Fylum.Core.Application.Command;

public interface ICommandHandler<TCommand>
    where TCommand : ICommand
{
    Result Handle(TCommand command);
}

public interface ICommandHandler<TCommand, TResult>
    where TCommand : ICommand<TResult>
{
    Result<TResult> Handle(TCommand command);
}