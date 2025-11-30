using Aspire.Hosting.Postgres;
using System.Text.Json;

namespace Fylum.AppHost;

public static class PgAdminExtensions
{
    public static IResourceBuilder<PgAdminContainerResource> WithSecureDynamicConfiguration(
        this IResourceBuilder<PgAdminContainerResource> pgAdminBuilder,
        IResourceBuilder<PostgresDatabaseResource> defaultConnectedDatabase)
    {
        // 2. Define paths in the "obj" directory to keep the project clean
        var configDir = Path.Combine(Directory.GetCurrentDirectory(),  "generated-config");
        Directory.CreateDirectory(configDir);

        var serversJsonPath = Path.Combine(configDir, "servers.json");
        var pgPassPath = Path.Combine(configDir, "pgpass");

        // 3. Define Container Paths
        // pgAdmin runs as user 5050 by default, so we map to a folder it can read
        var containerPassFilePath = "/pgadmin4/pgpass";

        // 4. Generate 'pgpass' file
        // Note: We use the resource name (postgresBuilder.Resource.Name) as the hostname.
        var databaseResource = defaultConnectedDatabase.Resource;
        var serverResource = databaseResource.Parent;
        // Format: hostname:port:database:username:password
        string hostname = serverResource.Name;
        int port = serverResource.Port.Endpoint.TargetPort!.Value;
        string databaseName = databaseResource.DatabaseName;
        string username = serverResource.UserNameParameter?.Value 
            ?? serverResource.UserNameReference?.ValueExpression
            ?? string.Empty;
        string password = serverResource.PasswordParameter.Value;
        IEnumerable<string> segments = [
            hostname,
            port.ToString()!,
            databaseName,
            username,
            password
            ];
        var pgPassContent = string.Join(":", segments);
        File.WriteAllText(pgPassPath, pgPassContent);

        // 5. Generate 'servers.json'
        var serverConfig = new
        {
            Servers = new Dictionary<string, object>
            {
                { "1", new
                    {
                        Name = "Fylum Local DB",
                        Group = "Servers",
                        Host = hostname,
                        Port = port,
                        Username = username,
                        SSLMode = "prefer",
                        MaintenanceDB = databaseName,
                        PassFile = containerPassFilePath // Point to the file we generated
                    }
                }
            }
        };

        var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
        File.WriteAllText(serversJsonPath, JsonSerializer.Serialize(serverConfig, jsonOptions));

        // 6. Mount the files
        pgAdminBuilder
            .WithBindMount(serversJsonPath, "/pgadmin4/servers.json")
            .WithBindMount(pgPassPath, containerPassFilePath);

        return pgAdminBuilder;
    }
}
