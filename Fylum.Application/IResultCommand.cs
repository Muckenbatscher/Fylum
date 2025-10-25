using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Application
{
    public interface IResultCommand<TParam, TResult> : ICommand<TParam>
    {
    }
}
