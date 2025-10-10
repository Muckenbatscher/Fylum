using Fylum.Files;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPostgreSqlServices(this IServiceCollection services)
        {
            services.AddRepositories();
            return services;
        }


        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IFileRepository, FileRepository>();
        }
    }
}
