using BuberBreakfast.Application.Authentication.Commands;
using BuberBreakfast.Application.Authentication.Queries.Login;
using BuberBreakfast.Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(ISender sender, IMapper mapper) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest requestBody)
    {
        var result = await sender.Send(mapper.Map<LoginQuery>(requestBody));

        var response = mapper.Map<AuthenticationResponse>(result);

        return Ok(response);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest requestBody)
    {
        var result = await sender.Send(mapper.Map<RegisterCommand>(requestBody));

        var response = mapper.Map<AuthenticationResponse>(result);

        return Ok(response);
    }
}
