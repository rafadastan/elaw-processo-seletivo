using elaw.Application.Interfaces;
using elaw.Application.Mappings;
using elaw.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elaw.Application
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(AddressProfile));
            services.AddAutoMapper(typeof(CustomerProfile));

            services.AddScoped<ICustomerApplicationService, CustomerApplicationService>();

            return services;
        }
    }
}
