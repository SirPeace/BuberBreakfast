using BuberBreakfast.Application.Exceptions;

namespace BuberBreakfast.Application.Common.Exceptions;

public class AppValidationException(string entityName, string? message = null) : AppException
{
    public override string Code => $"Common.Validation.{entityName}";

    public override Reasons Reason => Reasons.FailedValidation;

    public override string Message => message ?? "Failed to validate the passed data.";

    public Dictionary<string, IEnumerable<string>> Errors { get; init; } = new();
}
