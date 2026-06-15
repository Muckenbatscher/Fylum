using Fylum.ArchitectureTest.Common;
using NetArchTest.Rules;

namespace Fylum.Migrations.Api.Architecture.Tests;

[TestClass]
public class MigrationDependencyDirectionTests : DependencyDirectionTests
{
    protected override Types AssemblyTypes()
    {
        return Types.InAssemblies([
            typeof(Fylum.Migrations.Api.ServiceRegistration).Assembly
        ]);
    }

    protected override string RootNamespace => "Fylum.Migrations.Api";
}
