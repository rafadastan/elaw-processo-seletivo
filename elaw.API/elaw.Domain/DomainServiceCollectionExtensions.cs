using educaAcao.Domain.Notifications;
using elaw.Domain.Entities;
using elaw.Domain.Interfaces.Services;
using elaw.Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elaw.Domain
{
    public static class DomainServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<NotificationContext>();

            services.AddScoped<ICustomerDomainService, CustomerDomainService>();

            return services;
        }
    }
}
