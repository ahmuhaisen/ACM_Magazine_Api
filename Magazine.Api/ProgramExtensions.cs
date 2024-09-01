using Magazine.Application.Abstractions;
using Magazine.Application.Profiles;
using Magazine.Application.Services;
using Magazine.Infrastructure.Abstractions;
using Magazine.Infrastructure.Data;
using Magazine.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Magazine.Api;

public static class ProgramExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRepositories();
        services.AddDatabaseContextWithLogging(configuration);
        return services;
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddServices();
        services.AddAutoMapper(typeof(MappingProfile).Assembly);
        return services;
    }

    public static IServiceCollection AddPresentationServices(this IServiceCollection services)
    {
        services.AddSwaggerServices();
        return services;
    }


    private static void AddDatabaseContextWithLogging(this IServiceCollection services, IConfiguration configuration)
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
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IIssuesRepository, IssuesRepository>();
        services.AddScoped<IContributionsRepository, ContributionsRepository>();
        services.AddScoped<IVolunteersRepository, VolunteersRepository>();
    }

    private static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IIssuesService, IssuesService>();
        services.AddScoped<IVolunteersService, VolunteersService>();
    }

    private static void AddSwaggerServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.EnableAnnotations();
        });
    }
}
