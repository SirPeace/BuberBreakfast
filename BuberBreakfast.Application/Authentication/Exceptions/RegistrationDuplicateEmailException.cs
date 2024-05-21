using BuberBreakfast.Application.Exceptions;

namespace BuberBreakfast.Application.Authentication.Exceptions;

public class RegistrationDuplicateEmailException : AppException
{
    public override string Code => "Authentication.RegisterCommand.DuplicateEmail";

    public override Reasons Reason => Reasons.Conflict;

    public override string Message => "User with specified email is already registered.";
}
