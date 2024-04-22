using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.WebApi.Controllers;

public class ErrorController : ControllerBase
{
    [Route("/error")]
    public IActionResult Index()
    {
        var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        return Problem(exception?.Message);
    }
}