using Fylum.Core.Application.Query;
using Fylum.Migrations.Api.Architecture.Tests.CustomRules;
using NetArchTest.Rules;

namespace Fylum.Migrations.Api.Architecture.Tests;

[TestClass]
public sealed class ApplicationNamingTests
{
    private PredicateList CommandHandlerImplementations()
    {
        return Types.InAssembly(typeof(Program).Assembly)
            .That()
            .MeetCustomRule(new CommandHandlerImplementationRule());
    }
    private PredicateList QueryHandlerImplementations()
    {
        return Types.InAssembly(typeof(Program).Assembly)
            .That()
            .AreClasses()
            .And()
            .ImplementInterface(typeof(IQueryHandler<,>));
    }

    [TestMethod]
    public void CommandHandler_ShouldHave_NameEndingWith_CommandHandler()
    {
        CommandHandlerImplementations()
            .Should()
            .HaveNameEndingWith("CommandHandler")
            .GetResult()
            .AssertSuccessful();
    }
    [TestMethod]
    public void CommandHandlers_Should_Match_CommandName()
    {
        CommandHandlerImplementations()
            .Should()
            .MeetCustomRule(new CommandHandlerNameMatchesCommandRule())
            .GetResult()
            .AssertSuccessful();
    }

    [TestMethod]
    public void QueryHandler_ShouldHave_NameEndingWith_QueryHandler()
    {
        QueryHandlerImplementations()
            .Should()
            .HaveNameEndingWith("QueryHandler")
            .GetResult()
            .AssertSuccessful();
    }
    [TestMethod]
    public void QueryHandlers_Should_Match_QueryName()
    {
        QueryHandlerImplementations()
            .Should()
            .MeetCustomRule(new QueryHandlerNameMatchesQueryRule())
            .GetResult()
            .AssertSuccessful();
    }
}
