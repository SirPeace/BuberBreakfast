namespace BuberBreakfast.Application.Errors.Authentication;

public class RegistrationDuplicateEmailException : AppException
{
    public override string Code => "Authentication.Register.DuplicateEmail";

    public override Reasons Reason => Reasons.Conflict;

    public override string Message => "User with specified email is already registered.";
}
