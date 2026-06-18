using Fylum.ArchitectureTest.Common;
using NetArchTest.Rules;

namespace Fylum.Users.Api.Architecture.Tests;

[TestClass]
public class UsersDependencyDirectionTests : DependencyDirectionTests
{
    protected override Types AssemblyTypes()
    {
        return Types.InAssemblies([
            typeof(Fylum.Users.Api.UsersServiceRegistration).Assembly
        ]);
    }

    protected override string RootNamespace => "Fylum.Users.Api";
}
