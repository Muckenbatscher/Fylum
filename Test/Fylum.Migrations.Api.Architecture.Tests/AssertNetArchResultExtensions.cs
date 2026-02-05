using TestResult = NetArchTest.Rules.TestResult;

namespace Fylum.Migrations.Api.Architecture.Tests;

internal static class AssertNetArchResultExtensions
{
    extension(Assert)
    {
        public static void Successful(TestResult result)
        {
            Assert.IsTrue(result.IsSuccessful, $"Failing types: {string.Join(", ", result.FailingTypes)}");
        }
    }
}
