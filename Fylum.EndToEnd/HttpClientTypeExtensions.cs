using System.ComponentModel;

namespace Fylum.EndToEnd;

internal static class HttpClientTypeExtensions
{
    extension(HttpClientType httpClientType)
    {
        public string Name
            => httpClientType switch
            {
                HttpClientType.Api => "api",
                HttpClientType.MigrationApi => "migrations-api",
                _ => throw new InvalidEnumArgumentException(),
            };
    }
}
