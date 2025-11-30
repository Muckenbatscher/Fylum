using Fylum.Migrations.Domain.Providing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Migrations.Provider.MigrationFiles;

public interface IMigrationWithScripts
{
    Guid Id { get; }
    string Name { get; }
    bool IsMinimallyRequired => false;
    IEnumerable<FileInfo> MigrationScriptFiles { get; }

    public ProvidedMigration CreateMigration()
    {
        var scripts = GetMigrationScripts();
        var migration = ProvidedMigration.Create(Id, Name, scripts);
        if (IsMinimallyRequired)
            migration.MakeMinimallyRequired();
        return migration;
    }

    private IEnumerable<MigrationScript> GetMigrationScripts()
    {
        return MigrationScriptFiles.Select(f => new MigrationScript(File.ReadAllText(f.FullName)));
    }
}
