using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Application
{
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
}
