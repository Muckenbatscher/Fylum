using NetArchTest.Rules;

namespace Fylum.ArchitectureTest.Common;

[TestClass]
public abstract class DependencyDirectionTests
{
    private const string CoreApplicationNamespace = "Fylum.Core.Application";
    private const string CoreInfrastructureNamespace = "Fylum.Core.Infrastructure";

    private const string CommonDomainNamespaceExtension = "Common.Domain";
    private const string CommonApplicationNamespaceExtension = "Common.Application";
    private const string CommonInfrastructureNamespaceExtension = "Common.Infrastructure";
    private const string FeaturesNamespaceExtension = "Features";

    private string DomainNamespace => $"{RootNamespace}.{CommonDomainNamespaceExtension}";
    private string ApplicationNamespace => $"{RootNamespace}.{CommonApplicationNamespaceExtension}";
    private string InfrastructureNamespace => $"{RootNamespace}.{CommonInfrastructureNamespaceExtension}";
    private string FeaturesNamespace => $"{RootNamespace}.{FeaturesNamespaceExtension}";

    protected abstract string RootNamespace { get; }

    protected virtual Types AssemblyTypes() => Types.InCurrentDomain();

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
