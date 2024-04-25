using BuberBreakfast.Application.Authentication.Common;
using MediatR;

namespace BuberBreakfast.Application.Authentication.Commands;

public record RegisterCommand(string FirstName, string LastName, string Email, string Password)
    : IRequest<AuthenticationResult>;
