using Fylum.Migrations.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Migrations.Application.WithAppliedState
{
    public record MigrationWithAppliedState(Migration Migration, MigrationAppliedState? AppliedState)
    {
        public bool IsApplied => AppliedState != null;
    }
}
