using Fylum.Users.Application.Login;
using Fylum.Users.Application.Register;
using Fylum.Users.Domain;
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
        public static void AddUsersApplicationServices(this IServiceCollection services, Action<PasswordHashSettings> passwodHashSettingsOptions)
        {
            services.Configure(passwodHashSettingsOptions);

            services.AddTransient<IPasswordHashCalculator, PasswordHashCalculator>();
            services.AddTransient<IPasswordLoginVerification, PasswordLoginVerification>();

            services.AddTransient<IUserLoginCommandHandler, UserLoginCommandHandler>();
            services.AddTransient<IUserRegisterCommandHandler, UserRegisterCommandHandler>();
        }
    }
}
