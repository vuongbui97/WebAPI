using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyApp.Models;
using Microsoft.Extensions.DependencyInjection;

namespace MyApp.ServiceExtensions
{
    public static class SqlConnectConfigureServices
    {
        public static void SqlConnectConfigure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyDbContext>(option => 
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnection") 
                    ?? throw new InvalidOperationException("Connection string 'RazorPagesMovieContext' not found.")));
        }
    }
}
