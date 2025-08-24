using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum
{
    public interface IReadQuerier<T, Key> 
        where T : IdentifiableEntity<Key>
        where Key : struct
    {
        public T? GetById(Key id);
        public IEnumerable<T> GetAll();
    }
}
