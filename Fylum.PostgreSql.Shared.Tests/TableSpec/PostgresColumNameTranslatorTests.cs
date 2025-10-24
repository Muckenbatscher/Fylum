using Fylum.PostgreSql.TableSpec;

namespace Fylum.PostgreSql.Tests.TableSpec
{
    [TestClass]
    public sealed class PostgresColumNameTranslatorTests
    {
        [DataRow("PropertyName")]
        [DataRow("PROPERTY")]
        [DataRow("propertyName")]
        [TestMethod]
        public void NormalizedColumName_GivenPropertyName_ReturnsNoUpperCase(string propertyName)
        {
            var translator = new PostgresColumnNameTranslator();

            var translatedName = translator.GetNormalizedPostgresColumnName(propertyName);

            var hasUpperCase = translatedName.Any(char.IsUpper);
            Assert.IsFalse(hasUpperCase);
        }

        [DataRow("PropertyName", "property_name")]
        [DataRow("propertyName", "property_name")]
        [DataRow("property_Name", "property_name")]
        [DataRow("property__name", "property_name")]
        [DataRow("_Property", "property")]
        [DataRow("_property", "property")]
        [DataRow("PROPERTY", "property")]
        [DataRow("PROPERTYName", "property_name")]
        [TestMethod]
        public void NormalizedColumName_GivenPropertyName_MatchesExpected(string propertyName, string expectedColumnName)
        {
            var translator = new PostgresColumnNameTranslator();

            var translatedName = translator.GetNormalizedPostgresColumnName(propertyName);

            Assert.AreEqual(expectedColumnName, translatedName);
        }

        [DataRow("")]
        [DataRow("   ")]
        [TestMethod]
        public void NormalizedColumName_GivenEmptyPropertyName_ThrowsArgumentException(string propertyName)
        {
            var translator = new PostgresColumnNameTranslator();

            var translationAction = () => translator.GetNormalizedPostgresColumnName(string.Empty);

            Assert.Throws<ArgumentException>(translationAction);
        }

        [TestMethod]
        public void NormalizedColumName_GivenNullPropertyName_ThrowsArgumentException()
        {
            var translator = new PostgresColumnNameTranslator();

            var translationAction = () => translator.GetNormalizedPostgresColumnName(null!);

            Assert.Throws<ArgumentException>(translationAction);
        }
    }
}
