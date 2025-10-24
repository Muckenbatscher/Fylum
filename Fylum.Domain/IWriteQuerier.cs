using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Domain
{
    public interface IWriteQuerier<T, Key>
        where T : IdentifiableEntity<Key>
        where Key : struct
    {
        public void Create(T entity);
        public void Update(T entity);
        public void Delete(Key id);
    }
}
