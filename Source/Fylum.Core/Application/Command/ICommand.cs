namespace Fylum.Core.Application.Command;

public interface ICommand
{
}

public interface ICommand<TResult> : ICommand
{
}