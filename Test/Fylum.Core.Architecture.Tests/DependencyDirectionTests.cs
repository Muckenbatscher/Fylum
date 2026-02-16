using Fylum.ArchitectureTest.Common;
using NetArchTest.Rules;

namespace Fylum.Core.Architecture.Tests;

[TestClass]
public class DependencyDirectionTests
{
    private const string DomainNamespace = "Fylum.Core.Domain";
    private const string ApplicationNamespace = "Fylum.Core.Application";
    private const string InfrastructureNamespace = "Fylum.Core.Infrastructure";
    private const string PresentationNamespace = "Fylum.Core.Presentation";

    private Types AssemblyTypes() => Types.InCurrentDomain();

    // Domain
    [TestMethod]
    public void DomainLayer_ShouldNot_HaveDependencyOnApplication()
    {
        AssemblyTypes()
            .That()
            .ResideInNamespace(DomainNamespace)
            .ShouldNot()
            .HaveDependencyOn(ApplicationNamespace)
            .GetResult()
            .AssertSuccessful();
    }
    [TestMethod]
    public void DomainLayer_ShouldNot_HaveDependencyOnInfrastructure()
    {
        AssemblyTypes()
            .That()
            .ResideInNamespace(DomainNamespace)
            .ShouldNot()
            .HaveDependencyOn(InfrastructureNamespace)
            .GetResult()
            .AssertSuccessful();
    }
    [TestMethod]
    public void DomainLayer_ShouldNot_HaveDependencyOnPresentation()
    {
        AssemblyTypes()
            .That()
            .ResideInNamespace(DomainNamespace)
            .ShouldNot()
            .HaveDependencyOn(PresentationNamespace)
            .GetResult()
            .AssertSuccessful();
    }

    // Application
    [TestMethod]
    public void ApplicationLayer_ShouldNot_HaveDependencyOnInfrastructure()
    {
        AssemblyTypes()
            .That()
            .ResideInNamespace(ApplicationNamespace)
            .ShouldNot()
            .HaveDependencyOn(InfrastructureNamespace)
            .GetResult()
            .AssertSuccessful();
    }
    [TestMethod]
    public void ApplicationLayer_ShouldNot_HaveDependencyOnPresentation()
    {
        AssemblyTypes()
            .That()
            .ResideInNamespace(ApplicationNamespace)
            .ShouldNot()
            .HaveDependencyOn(PresentationNamespace)
            .GetResult()
            .AssertSuccessful();
    }

    // Infrastructure
    [TestMethod]
    public void InfrastructureLayer_ShouldNot_HaveDependencyOnPresentation()
    {
        AssemblyTypes()
            .That()
            .ResideInNamespace(InfrastructureNamespace)
            .ShouldNot()
            .HaveDependencyOn(PresentationNamespace)
            .GetResult()
            .AssertSuccessful();
    }

    // Presentation
    [TestMethod]
    public void PresentationLayer_ShouldNot_HaveDependencyOnInfrastructure()
    {
        AssemblyTypes()
            .That()
            .ResideInNamespace(PresentationNamespace)
            .ShouldNot()
            .HaveDependencyOn(InfrastructureNamespace)
            .GetResult()
            .AssertSuccessful();
    }
}
