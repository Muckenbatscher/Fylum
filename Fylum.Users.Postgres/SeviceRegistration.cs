using Fylum.Users.Domain;
using Fylum.Users.Domain.Groups;
using Fylum.Users.Domain.Password;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Users.Postgres
{
    public static class SeviceRegistration
    {
        public static void AddUsersPostgresServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserWithPasswordRepository, UserWithPasswordRepository>();
            services.AddScoped<IUserWithGroupsRepository, UserWithGroupsRepository>();
        }
    }
}
