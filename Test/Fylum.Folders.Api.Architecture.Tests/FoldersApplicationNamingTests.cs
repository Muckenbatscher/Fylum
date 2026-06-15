using Fylum.ArchitectureTest.Common;
using NetArchTest.Rules;

namespace Fylum.Folders.Api.Architecture.Tests;

[TestClass]
public class FoldersApplicationNamingTests : ApplicationNamingTests
{
    protected override Types AssemblyTypes()
    {
        return Types.InAssemblies([
            typeof(Fylum.Folders.Api.FoldersServiceRegistration).Assembly
        ]);
    }
}
