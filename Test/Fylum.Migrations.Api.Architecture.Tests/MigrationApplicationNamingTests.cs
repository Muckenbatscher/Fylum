using Fylum.ArchitectureTest.Common;
using NetArchTest.Rules;

namespace Fylum.Migrations.Api.Architecture.Tests;

[TestClass]
public class MigrationApplicationNamingTests : ApplicationNamingTests
{
    protected override Types AssemblyTypes()
    {
        return Types.InAssemblies([
            typeof(Fylum.Migrations.Api.ServiceRegistration).Assembly
        ]);
    }
}
