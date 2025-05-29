using elaw.Domain.Interfaces.Infra;
using elaw.Infra.Data.Repositories;
using elaw.Infra.Repositories;
using elaw.Infra.UOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace elaw.Infra
{
    public static class InfraServiceCollectionExtensions
    {
        public static IServiceCollection AddInfraDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
           options.UseInMemoryDatabase("ElawDB"));

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
