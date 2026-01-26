using Fylum.Folders.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Fylum.Folders.Postgres;

public static class ServiceRegistration
{
    extension(IServiceCollection services)
    {
        public void AddFolderPostgresServices()
        {
            services.AddTransient<IFolderRepository, FolderRepository>();
        }
    }
}
