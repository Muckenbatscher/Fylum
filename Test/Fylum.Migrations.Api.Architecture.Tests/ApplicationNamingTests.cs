using Fylum.Core.Application.Command;
using Fylum.Core.Application.Query;
using NetArchTest.Rules;

namespace Fylum.Migrations.Api.Architecture.Tests;

[TestClass]
public sealed class ApplicationNamingTests
{
    [TestMethod]
    public void CommandHandler_ShouldHave_NameEndingWith_CommandHandler()
    {
        var result = Types.InAssembly(typeof(Program).Assembly)
            .That()
            .ImplementInterface(typeof(ICommandHandler<>))
            .Or()
            .ImplementInterface(typeof(ICommandHandler<,>))
            .Should()
            .HaveNameEndingWith("CommandHandler")
            .GetResult();
        Assert.IsTrue(result.IsSuccessful, $"Failing types: { string.Join(", ", result.FailingTypes)}");
    }
    [TestMethod]
    public void QueryHandler_ShouldHave_NameEndingWith_QueryHandler()
    {
        var result = Types.InAssembly(typeof(Program).Assembly)
            .That()
            .ImplementInterface(typeof(IQueryHandler<,>))
            .Should()
            .HaveNameEndingWith("QueryHandler")
            .GetResult();
        Assert.IsTrue(result.IsSuccessful, $"Failing types: {string.Join(", ", result.FailingTypes)}");
    }
}
