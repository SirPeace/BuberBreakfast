using BuberBreakfast.Application.Common.Exceptions;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace BuberBreakfast.Application.Common.MediatrBehaviors;

public class ValidationBehavior<TRequest, TResponse>(IValidator<TRequest>? requestValidator = null)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken
    )
    {
        if (requestValidator is null)
            return await next();

        var validationResult = await requestValidator.ValidateAsync(request, cancellationToken);

        if (validationResult.IsValid)
            return await next();

        throw new AppValidationException(request.GetType().Name, "Sent request data is invalid.")
        {
            Errors = GetErrorsFromValidationResult(validationResult)
        };
    }

    private static Dictionary<string, IEnumerable<string>> GetErrorsFromValidationResult(
        ValidationResult validationResult
    )
    {
        Dictionary<string, IEnumerable<string>> errors = new();
        foreach (var error in validationResult.Errors)
        {
            if (!errors.ContainsKey(error.PropertyName))
                errors[error.PropertyName] = new List<string>();
            if (errors[error.PropertyName] is List<string> errorsList)
                errorsList.Add(error.ErrorMessage);
        }

        return errors;
    }
}
