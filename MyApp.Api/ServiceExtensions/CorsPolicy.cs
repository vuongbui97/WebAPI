using Microsoft.Extensions.DependencyInjection;

namespace MyApp.ServiceExtensions
{
    public static class CorsPolicy
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors( option =>
            {
                option.AddPolicy("CorsPolicy",
                    policy =>
                    {
                        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    });
                
            });
        }
    }
}
