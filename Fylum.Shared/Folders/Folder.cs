using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Folders
{
    public class Folder : IdentifiableEntity<Guid>
    {
        public Guid ParentFolderId { get; set; }
        public string Name { get; set; }
    }
}
