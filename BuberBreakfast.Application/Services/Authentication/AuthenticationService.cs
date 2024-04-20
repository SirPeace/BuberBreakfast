using BuberBreakfast.Application.Common.Interfaces;
using BuberBreakfast.Application.Common.Persistence;
using BuberBreakfast.Domain.Entities;

namespace BuberBreakfast.Application.Services.Authentication;

public class AuthenticationService(
    IJwtTokenGenerator jwtTokenGenerator,
    IUserRepository userRepository
) : IAuthenticationService
{
    public AuthenticationResult Login(string email, string password)
    {
        var user = userRepository.GetUserByEmail(email);

        if (user is null)
            throw new ArgumentException("Incorrect login/password.");
        if (password != user.Password)
            throw new ArgumentException("Incorrect login/password.");

        var token = jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName);
        Console.WriteLine($"Logged in as: {email}");

        return new AuthenticationResult(user, token);
    }

    public AuthenticationResult Register(
        string firstName,
        string lastName,
        string email,
        string password
    )
    {
        if (userRepository.GetUserByEmail(email) is not null)
            throw new ArgumentException("User with provided email already exists.");

        var newUser = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        userRepository.Add(newUser);

        var token = jwtTokenGenerator.GenerateToken(
            newUser.Id,
            newUser.FirstName,
            newUser.LastName
        );
        Console.WriteLine($"Registered new user: {firstName} {lastName}, {email}");

        return new AuthenticationResult(newUser, token);
    }
}
