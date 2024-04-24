using System.Net;
using BuberBreakfast.Application.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.WebApi.Controllers;

public class ErrorController : ControllerBase
{
    [Route("/error")]
    public IActionResult Index()
    {
        var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        var problem = exception switch
        {
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
}
