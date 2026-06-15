using Fylum.ArchitectureTest.Common;
using NetArchTest.Rules;

namespace Fylum.Users.Api.Architecture.Tests;

[TestClass]
public class UsersApplicationNamingTests : ApplicationNamingTests
{
    protected override Types AssemblyTypes()
    {
        return Types.InAssemblies([
            typeof(Fylum.Users.Api.UsersServiceRegistration).Assembly
        ]);
    }
}
