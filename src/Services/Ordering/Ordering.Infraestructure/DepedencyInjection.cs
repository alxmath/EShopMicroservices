global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Infraestructure;

public static class DepedencyInjection
{
    public static IServiceCollection AddInfraestructureServices
        (this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database");

        services.AddDbContext<ApplicationDbContext>(options => 
        {
            options.AddInterceptors(new AuditableEntityInterceptor());
            options.UseSqlServer(connectionString);
        });

        //services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

        return services;
    }
}
