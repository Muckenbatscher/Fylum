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
        public string Name { get; set; }
        public string ChangeDescription { get; set; }
        public string Content { get; set; }
    }
}
