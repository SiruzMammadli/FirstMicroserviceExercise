using IdentityService.DataAccess.Repositories.Abstracts;
using IdentityService.DataAccess.Repositories.Concretes;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityService.DataAccess.Extensions
{
    public static class Registration
    {
        public static IServiceCollection AddDataAccessRegistration(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
