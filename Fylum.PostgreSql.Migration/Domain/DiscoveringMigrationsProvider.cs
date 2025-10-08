using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.PostgreSql.Migration.Domain
{
    public class DiscoveringMigrationsProvider : IMigrationsProvider
    {
        public IEnumerable<IMigration> GetMigrations()
        {
            var assembly = Assembly.GetExecutingAssembly();

            var migrationInstances = assembly.GetTypes()
                .Where(IsDiscoverableMigration)
                .Select(type => Activator.CreateInstance(type) as IDiscoveredMigration)
                .Where(instance => instance != null).Cast<IDiscoveredMigration>()
                .OrderBy(instance => instance.ExecutionOrderPosition)
                .Select(instance => instance.Migration);
            return migrationInstances.ToList();
        }

        private bool IsDiscoverableMigration(Type type)
        {
            var targetInterface = typeof(IDiscoveredMigration);
            return !type.IsInterface && !type.IsAbstract && 
                   targetInterface.IsAssignableFrom(type);
        }
    }
}
