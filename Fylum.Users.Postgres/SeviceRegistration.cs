using Fylum.Users.Domain;
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
        }
    }
}
