using Fylum.Migrations.Application.GetMigrations;
using Fylum.Migrations.Application.MinimallyRequired;
using Fylum.Migrations.Application.Perform;
using Fylum.Migrations.Application.WithAppliedState;
using Fylum.Migrations.Domain.Perform;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Migrations.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddMigrationApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IMigrationWithAppliedStateService, MigrationWithAppliedStateService>();
            services.AddTransient<IMigrationPerformingService, MigrationPerformingService>();

            services.AddScoped<IPerformMigrationUnitOfWorkFactory, PerformMigrationUnitOfWorkFactory>();
            services.AddScoped<IMinimallyRequiredMigrationService, MinimallyRequiredMigrationService>();

            services.AddScoped<IGetMigrationCommandHandler, GetMigrationCommandHandler>();
            services.AddScoped<IGetAllMigrationsCommandHandler, GetAllMigrationsCommandHandler>();
            return services;
        }
    }
}
