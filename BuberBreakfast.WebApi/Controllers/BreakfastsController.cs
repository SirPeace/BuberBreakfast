using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.WebApi.Controllers;

[Route("[controller]")]
public class BreakfastsController : ApiController
{
    [HttpGet]
    public IActionResult GetBreakfasts()
    {
        return Ok(Array.Empty<string>());
    }
}
