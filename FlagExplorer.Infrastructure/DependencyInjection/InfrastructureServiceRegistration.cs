using FlagExplorer.Application.Interfaces;
using FlagExplorer.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FlagExplorer.Infrastructure.DependencyInjection;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<ICountryRepository, CountryRepository>();
        return services;
    }
}