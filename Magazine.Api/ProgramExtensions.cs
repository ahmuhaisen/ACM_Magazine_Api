using Magazine.Application.Abstractions;
using Magazine.Application.Services;
using Magazine.Infrastructure.Abstractions;
using Magazine.Infrastructure.Data;
using Magazine.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Magazine.Api;

public static class ProgramExtensions
{
    public static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IIssuesRepository, IssuesRepository>();
        services.AddScoped<IIssuesService, IssuesService>();

        return services;
    }
}
