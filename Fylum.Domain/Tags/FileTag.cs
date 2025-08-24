using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Tags
{
    public class FileTag : IdentifiableEntity<Guid>
    {
        public Guid FileId { get; set; }
        public Guid TagId { get; set; }
    }
}
