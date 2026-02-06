using TestResult = NetArchTest.Rules.TestResult;

namespace Fylum.Migrations.Api.Architecture.Tests;

internal static class AssertNetArchResultExtensions
{
    extension(TestResult result)
    {
        public void AssertSuccessful()
        {
            Assert.IsTrue(result.IsSuccessful, $"Failing types: {string.Join(", ", result.FailingTypes)}");
        }
    }
}
