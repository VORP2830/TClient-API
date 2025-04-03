using Clients.Application.DTOs.Mapping;
using Clients.Application.Interfaces;
using Clients.Application.Services;
using Clients.Domain.Interfaces;
using Clients.Infra.Data.Context;
using Clients.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clients.Infra.IoC;

public static class DependecyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
    {
        var connectionString = Environment.GetEnvironmentVariable("DATABASE") ?? configuration.GetConnectionString("ConnectionString");
        service.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString, b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        service.AddAutoMapper(typeof(MappingProfile));

        service.AddScoped<IUnitOfWork, UnitOfWork>();

        service.AddScoped<IClientService, ClientService>();
        service.AddScoped<IAddressService, AddressService>();

        return service;
    }
}