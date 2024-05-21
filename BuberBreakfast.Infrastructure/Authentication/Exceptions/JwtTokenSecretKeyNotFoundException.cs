using BuberBreakfast.Application.Common.Exceptions;
using BuberBreakfast.Application.Exceptions;

namespace BuberBreakfast.Infrastructure.Authentication.Exceptions;

public class JwtTokenSecretKeyNotFoundException : AppException
{
    public override string Code =>
        "Infrastructure.Authentication.JwtTokenGenerator.SecretKeyNotFound";

    public override Reasons Reason => Reasons.MissingConfiguration;

    public override string Message => "Unexpected error occured, please contact technical support.";
}
