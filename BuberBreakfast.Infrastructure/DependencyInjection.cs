using BuberBreakfast.Application.Common.Interfaces;
using BuberBreakfast.Infrastructure.Authentication;
using BuberBreakfast.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuberBreakfast.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration
    )
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

        services
            .AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>()
            .AddSingleton<IDateTimeProvider, DateTimeProvider>();

        return services;
    }
}
