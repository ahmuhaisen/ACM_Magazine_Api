using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Magazine.Domain.Entities;
using Magazine.Infrastructure.Data;
using Magazine.Application.Profiles;
using Magazine.Application.Services;
using Magazine.Application.Abstractions;
using Magazine.Infrastructure.Abstractions;
using Magazine.Infrastructure.Repositories;

using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

using Serilog;
using Magazine.Application.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Magazine.Api;

public static class ProgramExtensions
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection services)
    {
        services.AddSwaggerServices();
        services.AddCors(options => options
            .AddPolicy("AngularClient", policy =>
            {
                policy.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
            })
        );

        services.AddCaching();

        services.AddUserIdentity();
        return services;
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddServices();
        services.AddAutoMapper(typeof(MappingProfile).Assembly);
        services.AddJwt(configuration);
        return services;
    }

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRepositories();
        services.AddDatabaseContextWithLogging(configuration);
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

    private static void AddUserIdentity(this IServiceCollection services)
    {
        services.AddIdentity<ApplicationUser, IdentityRole>(options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
        })
            .AddEntityFrameworkStores<ApplicationDbContext>();

    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IIssuesRepository, IssuesRepository>();
        services.AddScoped<IContributionsRepository, ContributionsRepository>();
        services.AddScoped<IVolunteersRepository, VolunteersRepository>();
        services.AddScoped<IMessagesRepository, MessagesRepository>();
        services.AddScoped<IArticlesRepository, ArticlesRepository>();
    }

    private static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IIssuesService, IssuesService>();
        services.AddScoped<IVolunteersService, VolunteersService>();
        services.AddScoped<IMessagesService, MessagesService>();
        services.AddScoped<IArticlesService, ArticlesServices>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
    }

    private static void AddSwaggerServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.EnableAnnotations();
        });
    }

    private static void AddCaching(this IServiceCollection services)
    {
        services.AddResponseCaching();
    }

    private static void AddOpentelemetry(this IServiceCollection services)
    {
        services.AddOpenTelemetry()
            .ConfigureResource(resource => resource.AddService("ACMMagazineApi"))
            .WithMetrics(metrics =>
            {
                metrics.AddAspNetCoreInstrumentation()
                       .AddHttpClientInstrumentation();

                metrics.AddOtlpExporter();
            })
            .WithTracing(tracing =>
            {
                tracing.AddAspNetCoreInstrumentation()
                       .AddHttpClientInstrumentation()
                       .AddEntityFrameworkCoreInstrumentation();

                tracing.AddOtlpExporter();
            });
    }

    private static void AddJwt(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtOptions>(configuration.GetSection("Jwt"));

        var jwtOptions = configuration.GetSection("Jwt").Get<JwtOptions>();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = jwtOptions?.Issuer,
                    ValidAudience = jwtOptions?.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions?.SigningKey!)),
                    ClockSkew = TimeSpan.Zero
                };
            });
    }
}
