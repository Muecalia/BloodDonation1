using BloodDonation.Infrastructure.Interfaces;
using BloodDonation.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BloodDonation.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructute(this IServiceCollection services)
        {
            services.AddSevices();
            return services;
        }

        private static IServiceCollection AddSevices(this IServiceCollection services) 
        {
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IBloodStockRepository, BloodStockRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IDonationRepository, DonationRepository>();
            services.AddScoped<IDonorRepository, DonorRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ILogradouroRepository, LogradouroRepository>();
            services.AddScoped<IStateRepository, StateRepository>();
            return services;
        }

    }
}
