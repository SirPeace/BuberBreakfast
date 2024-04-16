using BuberBreakfast.Application.Services.Authentication;
using BuberBreakfast.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(IAuthenticationService _authService) : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login(LoginRequest requestBody)
    {
        var authResult = _authService.Login(requestBody.Email, requestBody.Password);

        var response = new AuthenticationResponse(
            Id: authResult.Id,
            FirstName: authResult.FirstName,
            LastName: authResult.LastName,
            Email: authResult.Email,
            Token: authResult.Token
        );

        return Ok(response);
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest requestBody)
    {
        var authResult = _authService.Register(
            requestBody.FirstName,
            requestBody.LastName,
            requestBody.Email,
            requestBody.Password
        );

        var response = new AuthenticationResponse(
            Id: authResult.Id,
            FirstName: authResult.FirstName,
            LastName: authResult.LastName,
            Email: authResult.Email,
            Token: authResult.Token
        );

        return Ok(response);
    }
}
