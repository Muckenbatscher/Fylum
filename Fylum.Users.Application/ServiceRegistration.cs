using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fylum.Users.Application
{
    public static class ServiceRegistration
    {
        public static void AddUsersApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IUserLoginCommandHandler, UserLoginCommandHandler>();
        }
    }
}
