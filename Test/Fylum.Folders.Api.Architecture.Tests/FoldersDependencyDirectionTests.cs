using Fylum.ArchitectureTest.Common;
using NetArchTest.Rules;

namespace Fylum.Folders.Api.Architecture.Tests;

[TestClass]
public class FoldersDependencyDirectionTests : DependencyDirectionTests
{
    protected override Types AssemblyTypes()
    {
        return Types.InAssemblies([
            typeof(Fylum.Folders.Api.FoldersServiceRegistration).Assembly
        ]);
    }
    protected override string RootNamespace => "Fylum.Folders.Api";
}
