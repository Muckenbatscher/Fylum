using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Tags
{
    public class Tag : IdentifiableEntity<Guid>
    {
        public string Name { get; set; }
    }
}
