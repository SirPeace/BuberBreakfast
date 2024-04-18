using BuberBreakfast.Application.Common.Interfaces;

namespace BuberBreakfast.Application.Services.Authentication;

public class AuthenticationService(IJwtTokenGenerator jwtTokenGenerator) : IAuthenticationService
{
    public AuthenticationResult Login(string email, string password)
    {
        Console.WriteLine($"Logged in as: {email} + {password}");
        return new AuthenticationResult(Guid.NewGuid(), "firstName", "lastName", email, "");
    }

    public AuthenticationResult Register(
        string firstName,
        string lastName,
        string email,
        string password
    )
    {
        var userId = Guid.NewGuid();
        var token = jwtTokenGenerator.GenerateToken(userId, firstName, lastName);

        Console.WriteLine($"Registered as: {firstName} {lastName} + {email} + {password}");
        return new AuthenticationResult(userId, firstName, lastName, email, token);
    }
}
