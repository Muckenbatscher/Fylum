namespace Fylum.Application;

public interface ICommand
{
}

public interface ICommand<TResult> : ICommand
{
}