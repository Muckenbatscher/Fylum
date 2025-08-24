using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Files
{
    public class FileCreationRequest
    {
        public string Name { get; set; }
        public Guid ParentFolderId { get; set; }
    }
}
