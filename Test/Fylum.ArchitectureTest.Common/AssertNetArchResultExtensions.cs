using TestResult = NetArchTest.Rules.TestResult;

namespace Fylum.ArchitectureTest.Common;

public static class AssertNetArchResultExtensions
{
    extension(TestResult result)
    {
        public void AssertSuccessful()
        {
            Assert.IsTrue(result.IsSuccessful, $"Failing types: {string.Join(", ", result.FailingTypes)}");
        }
    }
}
