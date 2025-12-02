using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Shared.Revisions
{
    public class RevisionResponse
    {
        public Guid Id { get; set; }
        public Guid FileId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ChangeDescription { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }
}
