using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Application
{
    public interface IResultCommandHandler<TCommand, TParam, TResult>
        where TCommand : IResultCommand<TParam, TResult>
    {
        TResult Handle(TCommand command);
    }
}
