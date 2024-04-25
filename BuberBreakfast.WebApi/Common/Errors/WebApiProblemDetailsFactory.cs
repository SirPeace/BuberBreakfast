using System.Diagnostics;
using BuberBreakfast.Application.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;

namespace BuberBreakfast.WebApi.Common.Errors;

// Source code: https://github.com/dotnet/aspnetcore/blob/main/src/Mvc/Mvc.Core/src/Infrastructure/DefaultProblemDetailsFactory.cs
/// <summary>
///     Copied from Microsoft.AspNetCore.Mvc.Infrastructure.DefaultProblemDetailsFactory.
///     This class's purpose is in the new method, which adds custom fields to the error response.
/// </summary>
public class WebApiProblemDetailsFactory(
    IOptions<ApiBehaviorOptions> options,
    IOptions<ProblemDetailsOptions>? problemDetailsOptions = null
) : Microsoft.AspNetCore.Mvc.Infrastructure.ProblemDetailsFactory
{
    private readonly Action<ProblemDetailsContext>? _configure = problemDetailsOptions
        ?.Value
        ?.CustomizeProblemDetails;

    private readonly ApiBehaviorOptions _options =
        options?.Value ?? throw new ArgumentNullException(nameof(options));

    public override ProblemDetails CreateProblemDetails(
        HttpContext httpContext,
        int? statusCode = null,
        string? title = null,
        string? type = null,
        string? detail = null,
        string? instance = null
    )
    {
        statusCode ??= 500;

        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Type = type,
            Detail = detail,
            Instance = instance
        };

        ApplyProblemDetailsDefaults(httpContext, problemDetails, statusCode.Value);

        return problemDetails;
    }

    public override ValidationProblemDetails CreateValidationProblemDetails(
        HttpContext httpContext,
        ModelStateDictionary modelStateDictionary,
        int? statusCode = null,
        string? title = null,
        string? type = null,
        string? detail = null,
        string? instance = null
    )
    {
        ArgumentNullException.ThrowIfNull(modelStateDictionary);

        statusCode ??= 400;

        var problemDetails = new ValidationProblemDetails(modelStateDictionary)
        {
            Status = statusCode,
            Type = type,
            Detail = detail,
            Instance = instance
        };

        if (title != null)
            // For validation problem details, don't overwrite the default title with null.
            problemDetails.Title = title;

        ApplyProblemDetailsDefaults(httpContext, problemDetails, statusCode.Value);

        return problemDetails;
    }

    private void ApplyProblemDetailsDefaults(
        HttpContext httpContext,
        ProblemDetails problemDetails,
        int statusCode
    )
    {
        problemDetails.Status ??= statusCode;

        if (_options.ClientErrorMapping.TryGetValue(statusCode, out var clientErrorData))
        {
            problemDetails.Title ??= clientErrorData.Title;
            problemDetails.Type ??= clientErrorData.Link;
        }

        var traceId = Activity.Current?.Id ?? httpContext?.TraceIdentifier;
        if (traceId != null)
            problemDetails.Extensions["traceId"] = traceId;

        _configure?.Invoke(
            new ProblemDetailsContext
            {
                HttpContext = httpContext!,
                ProblemDetails = problemDetails
            }
        );

        var exception = httpContext?.Features.Get<IExceptionHandlerFeature>()?.Error;
        AddApplicationProblemDetailsExtensions(problemDetails, exception);
    }

    /// <summary>
    ///     This is where we add our custom fields to the error body
    /// </summary>
    /// <param name="problemDetails"></param>
    private static void AddApplicationProblemDetailsExtensions(
        ProblemDetails problemDetails,
        Exception? exception
    )
    {
        if (exception is AppException appException)
        {
            problemDetails.Extensions["code"] = appException.Code;
        }

        problemDetails.Extensions["customProperty"] = "customValue";
    }
}
