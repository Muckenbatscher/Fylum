using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Shared.Files
{
    public class FileResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ParentFolderId { get; set; }
        public Guid LatestRevisionId { get; set; }
    }
}
