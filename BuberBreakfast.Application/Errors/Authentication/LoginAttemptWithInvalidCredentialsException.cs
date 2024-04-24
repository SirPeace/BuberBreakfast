namespace BuberBreakfast.Application.Errors.Authentication;

public class LoginAttemptWithInvalidCredentialsException : AppException
{
    public override string Code => "Authentication.Login.InvalidCredentials";

    public override Reasons Reason => Reasons.Forbidden;

    public override string Message => "Invalid email/password.";
}
