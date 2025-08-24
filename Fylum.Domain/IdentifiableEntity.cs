using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum
{
    public abstract class IdentifiableEntity<Key> 
        where Key : struct
    {
        public Key Id { get; set; }
    }
}
