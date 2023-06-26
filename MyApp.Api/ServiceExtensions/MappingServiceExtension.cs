using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyApp.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace MyApp.ServiceExtensions
{
    public static class MappingServiceExtension
    {
        public static void MappingServices(this IServiceCollection services) 
        {
            services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });

            var mappingConfig = new MapperConfiguration(map =>
            {
                map.AddProfile<RegisterMappingUser>();
            });

            services.AddSingleton(mappingConfig.CreateMapper());
        }
    }
}
