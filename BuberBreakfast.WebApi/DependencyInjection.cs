using BuberBreakfast.WebApi.Common.Errors;
using BuberBreakfast.WebApi.Mappings;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BuberBreakfast.WebApi;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer().AddSwaggerGen().AddControllers();

        services.AddMappings();
        services.AddSingleton<ProblemDetailsFactory, WebApiProblemDetailsFactory>();

        return services;
    }
}
