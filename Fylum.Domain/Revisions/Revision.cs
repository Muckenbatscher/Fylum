using Fylum.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Domain.Revisions
{
    public class Revision : IdentifiableEntity<Guid>
    {
        public Guid FileId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ChangeDescription { get; set; } = string.Empty;
        public DateTime CreationTimestampUtc { get; set; }
    }
}
