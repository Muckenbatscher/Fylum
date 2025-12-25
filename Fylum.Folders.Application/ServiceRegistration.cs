using Fylum.Application;
using Fylum.Folders.Application.CreateFolder;
using Fylum.Folders.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Fylum.Folders.Application;

public static class ServiceRegistration
{
    extension(IServiceCollection services)
    {
        public void AddFolderApplicationServices()
        {
            services.AddScoped<IFolderUnitOfWorkFactory, FolderUnitOfWorkFactory>();

            services.AddTransient<ICommandHandler<CreateFolderCommand, CreateFolderResult>, CreateFolderCommandHandler>();
        }
    }
}
