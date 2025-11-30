using Fylum.Migrations.Domain.Providing;
using System.Reflection;
using System.Text;

namespace Fylum.Migrations.Provider;

public abstract class MigrationFromEmbeddedResources
{
    public abstract Guid Id { get; }
    public abstract string Name { get; }
    public virtual bool IsMinimallyRequired => false;

    protected abstract IEnumerable<string> ResourceFolderNameParts { get; }
    protected abstract IEnumerable<string> ResourceNames { get; }

    protected virtual Assembly ResourceAssembly => GetType().Assembly;

    public ProvidedMigration CreateMigration()
    {
        var scripts = GetMigrationScripts();
        var migration = ProvidedMigration.Create(Id, Name, scripts);
        if (IsMinimallyRequired)
            migration.MakeMinimallyRequired();
        return migration;
    }

    protected IEnumerable<MigrationScript> GetMigrationScripts()
    {
        var assembly = ResourceAssembly;

        var assemblyName = assembly.GetName().Name ?? string.Empty;
        var normalizedFolderParts = ResourceFolderNameParts.Select(GetNormalizedResourceName);
        var folderNameParts = string.Join(".", normalizedFolderParts);
        var prefix = $"{assemblyName}.{folderNameParts}";

        foreach (var resourceName in ResourceNames)
        {
            var fullResourceName = $"{prefix}.{resourceName}";
            using var stream = assembly.GetManifestResourceStream(fullResourceName)
                ?? throw new FileNotFoundException($"Embedded resource not found: {fullResourceName}");

            using var reader = new StreamReader(stream, Encoding.UTF8);
            var scriptCommandText = reader.ReadToEnd();
            yield return new MigrationScript(scriptCommandText);
        }
    }

    private string GetNormalizedResourceName(string resourceName)
    {
        resourceName = resourceName.Trim();
        if (string.IsNullOrWhiteSpace(resourceName))
            return string.Empty;
        if (!char.IsLetter(resourceName.First()))
            return $"_{resourceName}";

        return resourceName;
    }

}