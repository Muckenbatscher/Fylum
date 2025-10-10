using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.PostgreSql.Shared.TableSpec
{
    public class PostgresColumnNameTranslator : IPostgresColumnNameTranslator
    {
        public string GetNormalizedPostgresColumnName(string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Property name cannot be null or whitespace.", nameof(propertyName));

            var normalizedNameBuilder = new StringBuilder();
            for (int i = 0; i < propertyName.Length; i++)
            {
                char currentChar = propertyName[i];

                if (char.IsUpper(currentChar))
                {
                    bool isFirstChar = i == 0;
                    bool isLastChar = i >= propertyName.Length - 1;
                    bool isPrevCharLower = !isFirstChar && char.IsLower(propertyName[i - 1]);
                    bool isPrevCharUpper = !isFirstChar && char.IsUpper(propertyName[i - 1]);
                    bool isNextCharLower = !isLastChar && char.IsLower(propertyName[i + 1]);

                    if (isPrevCharLower || (isPrevCharUpper && isNextCharLower))
                        normalizedNameBuilder.Append('_');

                    normalizedNameBuilder.Append(char.ToLower(currentChar));
                }
                else if (currentChar == '_')
                {
                    bool isPrevAppendedCharUnderscore = normalizedNameBuilder.Length == 0 || normalizedNameBuilder[normalizedNameBuilder.Length - 1] == '_';
                    if (!isPrevAppendedCharUnderscore)
                        normalizedNameBuilder.Append('_');
                }
                else
                {
                    normalizedNameBuilder.Append(currentChar);
                }
            }

            // Entfernt am Ende führende oder nachfolgende Unterstriche
            string result = normalizedNameBuilder.ToString();
            return result.Trim('_').ToLower();
        }
    }
}
