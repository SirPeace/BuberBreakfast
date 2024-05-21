using BuberBreakfast.Application.Authentication.Commands.Register;
using BuberBreakfast.Application.Authentication.Common;
using BuberBreakfast.Application.Authentication.Exceptions;
using BuberBreakfast.Application.Common.Interfaces;
using BuberBreakfast.Application.Common.Persistence;
using BuberBreakfast.Domain.Entities;
using MediatR;

namespace BuberBreakfast.Application.Authentication.Commands.Register;

public class RegisterCommandHandler(
    IUserRepository userRepository,
    IJwtTokenGenerator jwtTokenGenerator
) : IRequestHandler<RegisterCommand, AuthenticationResult>
{
    public async Task<AuthenticationResult> Handle(
        RegisterCommand request,
        CancellationToken cancellationToken
    )
    {
        return await Task.FromResult(
            Register(request.FirstName, request.LastName, request.Email, request.Password)
        );
    }

    private AuthenticationResult Register(
        string firstName,
        string lastName,
        string email,
        string password
    )
    {
        if (userRepository.GetUserByEmail(email) is not null)
            throw new RegistrationDuplicateEmailException();

        var newUser = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        userRepository.Add(newUser);

        var token = jwtTokenGenerator.GenerateToken(newUser);
        Console.WriteLine($"Registered new user: {firstName} {lastName}, {email}");

        return new AuthenticationResult(newUser, token);
    }
}
