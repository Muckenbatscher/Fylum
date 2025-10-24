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
        public string Name { get; set; }
        public string ChangeDescription { get; set; }
        public DateTime CreationTimestampUtc { get; set; }
    }
}
