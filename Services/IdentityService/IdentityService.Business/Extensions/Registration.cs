using IdentityService.Business.Services.Abstracts;
using IdentityService.Business.Services.Concretes;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityService.Business.Extensions
{
    public static class Registration
    {
        public static IServiceCollection AddBusinessRegistration(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IAuthService, AuthManager>();

            return services;
        }
    }
}
