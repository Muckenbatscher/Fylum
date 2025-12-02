using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Domain.Tags
{
    public abstract class TagValue<T> : Tag 
        where T : notnull
    {
        public T Value { get; set; } = default!;
    }
}
