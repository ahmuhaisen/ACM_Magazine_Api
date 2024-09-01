using Magazine.Application.Abstractions;
using Magazine.Application.Services;
using Magazine.Infrastructure.Abstractions;
using Magazine.Infrastructure.Data;
using Magazine.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Magazine.Api;

public static class ProgramExtensions
{


    public static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
    {
        var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddSerilog()
            .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information);
        });

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                .UseLoggerFactory(loggerFactory)
                .EnableSensitiveDataLogging();
        });

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IIssuesRepository, IssuesRepository>();
        services.AddScoped<IContributionsRepository, ContributionsRepository>();
        services.AddScoped<IVolunteersRepository, VolunteersRepository>();

        return services;
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IIssuesService, IssuesService>();
        services.AddScoped<IVolunteersService, VolunteersService>();

        return services;
    }
}
