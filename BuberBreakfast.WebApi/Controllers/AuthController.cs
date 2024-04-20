using BuberBreakfast.Application.Services.Authentication;
using BuberBreakfast.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(IAuthenticationService authService) : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login(LoginRequest requestBody)
    {
        var (user, token) = authService.Login(requestBody.Email, requestBody.Password);

        var response = new AuthenticationResponse(
            user.Id,
            user.FirstName,
            user.LastName,
            user.Email,
            token
        );

        return Ok(response);
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest requestBody)
    {
        var (user, token) = authService.Register(
            requestBody.FirstName,
            requestBody.LastName,
            requestBody.Email,
            requestBody.Password
        );

        var response = new AuthenticationResponse(
            user.Id,
            user.FirstName,
            user.LastName,
            user.Email,
            token
        );

        return Ok(response);
    }
}
