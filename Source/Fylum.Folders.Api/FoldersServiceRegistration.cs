using Fylum.Core;
using Fylum.Folders.Api.Common.Domain;
using Fylum.Folders.Api.Common.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Fylum.Folders.Api;

public static class FoldersServiceRegistration
{
    public static IServiceCollection AddFoldersServices(this IServiceCollection services)
    {
        return services
            .AddCoreServices()
            .AddPostgresRepositories();
    }

    private static IServiceCollection AddPostgresRepositories(this IServiceCollection services)
    {
        return services
            .AddTransient<IFolderRepository, FolderRepository>();
    }
}
