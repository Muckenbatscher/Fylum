using Fylum.ArchitectureTest.Common.CustomRules;
using Fylum.Core.Application.Query;
using NetArchTest.Rules;

namespace Fylum.ArchitectureTest.Common;

public abstract class ApplicationNamingTests
{
    protected virtual Types AssemblyTypes() => Types.InCurrentDomain();

    private PredicateList CommandHandlerImplementations()
    {
        return AssemblyTypes()
            .That()
            .MeetCustomRule(new CommandHandlerImplementationRule());
    }
    private PredicateList QueryHandlerImplementations()
    {
        return AssemblyTypes()
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
