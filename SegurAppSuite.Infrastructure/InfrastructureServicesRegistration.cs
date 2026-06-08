using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SegurAppSuite.Domain.Interfaces;
using SegurAppSuite.Infrastructure.Persistence;
using SegurAppSuite.Infrastructure.Persistence.Repositories;

namespace SegurAppSuite.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Configurar EF Core
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        // Registrar repositorios
        services.AddScoped<IClienteRepository, ClienteRepositoryEF>();
        services.AddScoped<IPolizaRepository, PolizaRepositoryEF>();
        services.AddScoped<ISiniestroRepository, SiniestroRepositoryEF>();
        return services;
    }
}
