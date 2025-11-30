using Aspire.Hosting;
using Aspire.Hosting.Postgres;
using System.Text.Json;

namespace Fylum.AppHost;

public static class PgAdminExtensions
{
    public static IResourceBuilder<PgAdminContainerResource> WithSecureDynamicConfiguration(
        this IResourceBuilder<PgAdminContainerResource> pgAdminBuilder,
        IResourceBuilder<PostgresDatabaseResource> defaultConnectedDatabase)
    {
        //paths on host machine
        var configDir = Path.Combine(Directory.GetCurrentDirectory(), "bin", "generated-config");
        Directory.CreateDirectory(configDir);

        var serversJsonPath = Path.Combine(configDir, "servers.json");
        var pgPassPath = Path.Combine(configDir, "pgpass");

        //use a TEMP path for the mount, and the FINAL path for the actual usage.
        var tempPassFilePath = "/tmp/pgpass_temp";
        var finalPassFilePath = "/var/lib/pgadmin/pgpass";

        var databaseResource = defaultConnectedDatabase.Resource;
        var serverResource = databaseResource.Parent;

        var valueEvalCancellationToken = new CancellationToken();
        string hostname = serverResource.Name;
        int port = serverResource.Port.Endpoint.TargetPort ?? 5432;
        string databaseName = databaseResource.DatabaseName;
        var usernameEvalTask = serverResource.UserNameParameter?.GetValueAsync(valueEvalCancellationToken);
        while (!usernameEvalTask.HasValue || !usernameEvalTask.Value.IsCompleted) { }
        string username = usernameEvalTask.Value.Result
            ?? serverResource.UserNameReference?.ValueExpression
            ?? "postgres";
        var passwordEvalTask = serverResource.PasswordParameter?.GetValueAsync(valueEvalCancellationToken);
        while (!passwordEvalTask.HasValue || !passwordEvalTask.Value.IsCompleted) { }
        string password = passwordEvalTask.Value.Result ?? "";

        IEnumerable<string> segments = [
            hostname,
            port.ToString(),
            databaseName,
            username,
            password
        ];

        // pgpass format: hostname:port:database:username:password
        var pgPassContent = string.Join(":", segments);
        File.WriteAllText(pgPassPath, pgPassContent);

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
                        PassFile = finalPassFilePath // Point to the FINAL path
                    }
                }
            }
        };

        var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
        File.WriteAllText(serversJsonPath, JsonSerializer.Serialize(serverConfig, jsonOptions));

        pgAdminBuilder
            .WithBindMount(serversJsonPath, "/pgadmin4/servers.json")
            // Mount the passfile to the TEMP location, not the final one
            .WithBindMount(pgPassPath, tempPassFilePath)
            .WithEnvironment("PGPASSFILE", finalPassFilePath);

        //copy the passfile from the TEMP location to the final location
        //set the file permission that pgadmin expects in order to be able to use the file
        pgAdminBuilder.WithEntrypoint("/bin/sh");
        pgAdminBuilder.WithArgs("-c",
            $"cp {tempPassFilePath} {finalPassFilePath} && " +
            $"chmod 600 {finalPassFilePath} && " +
            $"exec /entrypoint.sh");

        return pgAdminBuilder;
    }
}
