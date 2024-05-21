using System.Net;
using BuberBreakfast.Application.Common.Exceptions;
using BuberBreakfast.Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BuberBreakfast.WebApi.Controllers;

public class ErrorController : ControllerBase
{
    [Route("/error")]
    public IActionResult Index()
    {
        var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        var problem = exception switch
        {
            AppValidationException e
                => ValidationProblem(
                    detail: e.Message,
                    statusCode: GetHttpCodeFromApplicationException(e),
                    modelStateDictionary: GetModelStateDictionaryFromValidationException(e)
                ),
            AppException e
                => Problem(detail: e.Message, statusCode: GetHttpCodeFromApplicationException(e)),
            _ => Problem()
        };

        return problem;
    }

    private static int GetHttpCodeFromApplicationException(AppException exception)
    {
        return (int)(
            exception.Reason switch
            {
                Reasons.AuthenticationRequired => HttpStatusCode.Unauthorized,
                Reasons.Conflict => HttpStatusCode.Conflict,
                Reasons.FailedValidation => HttpStatusCode.UnprocessableContent,
                Reasons.Forbidden => HttpStatusCode.Forbidden,
                Reasons.NotFound => HttpStatusCode.NotFound,
                Reasons.TimeoutExceed => HttpStatusCode.GatewayTimeout,
                _ => HttpStatusCode.InternalServerError
            }
        );
    }

    private static ModelStateDictionary GetModelStateDictionaryFromValidationException(
        AppValidationException e
    )
    {
        var modelStateDictionary = new ModelStateDictionary();

        foreach (var (key, errors) in e.Errors)
        foreach (var errorMessage in errors)
            modelStateDictionary.AddModelError(key, errorMessage);

        return modelStateDictionary;
    }
}
