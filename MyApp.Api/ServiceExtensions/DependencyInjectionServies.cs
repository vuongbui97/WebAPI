using Microsoft.Extensions.DependencyInjection;
using MyApp.Repositories.UserRepository;
using MyApp.Services.AuthenticateSevice;

namespace MyApp.ServiceExtensions
{
    public static class DependencyInjectionServies
    {
        public static void DependencyInjectionContainerServices(this IServiceCollection services) 
        {
            services.AddScoped<IAuthenticateService, AuthenticateService>();
            services.AddScoped<IUserRepository, UserRepository>();

        }
    }
}
