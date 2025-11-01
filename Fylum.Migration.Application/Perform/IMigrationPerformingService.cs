using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Migration.Application.Perform
{
    public interface IMigrationPerformingService
    {
        void Perform(Domain.Migration migration);
    }
}
