using BuberBreakfast.Application.Authentication.Common;
using BuberBreakfast.Application.Authentication.Exceptions;
using BuberBreakfast.Application.Authentication.Queries.Login;
using BuberBreakfast.Application.Common.Interfaces;
using BuberBreakfast.Application.Common.Persistence;
using MediatR;

namespace BuberBreakfast.Application.Authentication.Queries;

public class LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    : IRequestHandler<LoginQuery, AuthenticationResult>
{
    public async Task<AuthenticationResult> Handle(
        LoginQuery request,
        CancellationToken cancellationToken
    )
    {
        return await Task.FromResult(Login(request.Email, request.Password));
    }

    protected AuthenticationResult Login(string email, string password)
    {
        var user = userRepository.GetUserByEmail(email);

        if (user is null || password != user.Password)
            throw new LoginAttemptWithInvalidCredentialsException();

        var token = jwtTokenGenerator.GenerateToken(user);
        Console.WriteLine($"Logged in as: {email}");

        return new AuthenticationResult(user, token);
    }
}
