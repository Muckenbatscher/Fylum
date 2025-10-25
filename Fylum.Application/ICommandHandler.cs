using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Application
{
    public interface ICommandHandler<TCommand, TParam>
        where TCommand : ICommand<TParam>
    {
        void Handle(TCommand command);
    }
}
