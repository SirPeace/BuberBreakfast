using BuberBreakfast.Application.Common.Exceptions;
using BuberBreakfast.Application.Exceptions;

namespace BuberBreakfast.Application.Authentication.Exceptions;

public class LoginAttemptWithInvalidCredentialsException : AppException
{
    public override string Code => "Authentication.LoginQuery.InvalidCredentials";

    public override Reasons Reason => Reasons.Forbidden;

    public override string Message => "Invalid email/password.";
}
