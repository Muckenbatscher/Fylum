using Fylum.Application;
using Microsoft.Extensions.DependencyInjection;

namespace Fylum.Folders.Application;

public static class ServiceRegistration
{
    extension(IServiceCollection services)
    {
        public void AddFolderApplicationServices()
        {
            services.AddUnitOfWorkFactories();
            services.AddQueryHandlers();
            services.AddCommandHandlers();
        }
    }
}
