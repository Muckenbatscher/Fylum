using NetArchTest.Rules;

namespace Fylum.Migrations.Api.Architecture.Tests;

[TestClass]
public class DependencyDirectionTests
{
    private const string CoreApplicationNamespace = "Fylum.Core.Application";
    private const string CoreInfrastructureNamespace = "Fylum.Core.Infrastructure";

    private const string DomainNamespace = "Fylum.Migrations.Api.Common.Domain";
    private const string ApplicationNamespace = "Fylum.Migrations.Api.Common.Application";
    private const string InfrastructureNamespace = "Fylum.Migrations.Api.Common.Infrastructure";
    private const string FeaturesNamespace = "Fylum.Migrations.Api.Features";

    private Types AssemblyTypes() => Types.InCurrentDomain();

    [TestMethod]
    public void CommonDomainLayer_ShouldNot_HaveDependencyOnApplication()
    {
        AssemblyTypes()
            .That()
            .ResideInNamespace(DomainNamespace)
            .ShouldNot()
            .HaveDependencyOnAny(ApplicationNamespace, CoreApplicationNamespace)
            .GetResult()
            .AssertSuccessful();
    }
    [TestMethod]
    public void CommonDomainLayer_ShouldNot_HaveDependencyOnInfrastructure()
    {
        AssemblyTypes()
            .That()
            .ResideInNamespace(DomainNamespace)
            .ShouldNot()
            .HaveDependencyOnAny(InfrastructureNamespace, CoreInfrastructureNamespace)
            .GetResult()
            .AssertSuccessful();
    }
    [TestMethod]
    public void CommonDomainLayer_ShouldNot_HaveDependencyOnFeatures()
    {
        AssemblyTypes()
            .That()
            .ResideInNamespace(DomainNamespace)
            .ShouldNot()
            .HaveDependencyOn(FeaturesNamespace)
            .GetResult()
            .AssertSuccessful();
    }

    [TestMethod]
    public void CommonApplicationLayer_ShouldNot_HaveDependencyOnInfrastructure()
    {
        AssemblyTypes()
            .That()
            .ResideInNamespace(ApplicationNamespace)
            .ShouldNot()
            .HaveDependencyOnAny(InfrastructureNamespace, CoreInfrastructureNamespace)
            .GetResult()
            .AssertSuccessful();
    }
    [TestMethod]
    public void CommonApplicationLayer_ShouldNot_HaveDependencyOnFeatures()
    {
        AssemblyTypes()
            .That()
            .ResideInNamespace(ApplicationNamespace)
            .ShouldNot()
            .HaveDependencyOn(FeaturesNamespace)
            .GetResult()
            .AssertSuccessful();
    }

    [TestMethod]
    public void CommonInfrastructureLayer_ShouldNot_HaveDependencyOnFeatures()
    {
        AssemblyTypes()
            .That()
            .ResideInNamespace(InfrastructureNamespace)
            .ShouldNot()
            .HaveDependencyOn(FeaturesNamespace)
            .GetResult()
            .AssertSuccessful();
    }

    [TestMethod]
    public void Features_ShouldNot_HaveDirectDependencyOnInfrastructure()
    {
        AssemblyTypes()
            .That()
            .ResideInNamespace(FeaturesNamespace)
            .ShouldNot()
            .HaveDependencyOnAny(InfrastructureNamespace, CoreInfrastructureNamespace)
            .GetResult()
            .AssertSuccessful();
    }
}
