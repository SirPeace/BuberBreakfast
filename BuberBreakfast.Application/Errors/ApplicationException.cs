namespace BuberBreakfast.Application.Errors;

public abstract class AppException : Exception
{
    /// <summary>
    ///     Unique identifier for an exception to track it easier.
    /// </summary>
    public abstract string Code { get; }

    /// <summary>
    ///     Reason for raising the exception. Universal alternative to HTTP code.
    /// </summary>
    public abstract Reasons Reason { get; }

    /// <summary>
    ///     Human-readable details about occurred exception.
    /// </summary>
    public new abstract string Message { get; }
}
