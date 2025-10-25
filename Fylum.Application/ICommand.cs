using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Application
{
    public interface ICommand<TParam>
    {
        TParam Parameter { get; }
    }
}
