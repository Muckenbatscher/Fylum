using Fylum.ArchitectureTest.Common;

namespace Fylum.Migrations.Api.Architecture.Tests;

[TestClass]
public class MigrationDependencyDirectionTests : DependencyDirectionTests
{
    protected override string RootNamespace => "Fylum.Migrations.Api";
}
