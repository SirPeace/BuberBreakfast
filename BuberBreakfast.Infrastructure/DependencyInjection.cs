using System.Text;
using BuberBreakfast.Application.Common.Interfaces;
using BuberBreakfast.Application.Common.Persistence;
using BuberBreakfast.Infrastructure.Authentication;
using BuberBreakfast.Infrastructure.Persistence;
using BuberBreakfast.Infrastructure.Persistence.Repositories.MenuRepositories;
using BuberBreakfast.Infrastructure.Persistence.Repositories.UserRepositories;
using BuberBreakfast.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BuberBreakfast.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services
            .AddSingleton<IDateTimeProvider, DateTimeProvider>()
            .AddAuth(configuration)
            .AddPersistence(configuration);

        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration
            .GetSection("SqlServer")
            .GetValue<string>("ConnectionString");
        
        services.AddDbContext<BuberBreakfastDbContext>(opt => opt.UseSqlServer(connectionString));

        services
            .AddScoped<IUserRepository, UserInMemoryRepository>()
            .AddScoped<IMenuRepository, MenuEFRepository>();

        return services;
    }

    private static IServiceCollection AddAuth(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services
            .AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt =>
                opt.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings.Secret)
                    )
                }
            );

        return services;
    }
}
