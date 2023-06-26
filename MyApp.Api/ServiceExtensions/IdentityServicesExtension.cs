using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Models;

namespace MyApp.ServiceExtensions
{
    public static class IdentityServicesExtension
    {

        public static void ConfigureIdentity(this IServiceCollection services) 
        {
        
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit= false;
                options.Password.RequireLowercase= false;
                options.Password.RequireUppercase= false;
                options.Password.RequireNonAlphanumeric = false;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<MyDbContext>().AddDefaultTokenProviders();
        }
    }
}
