namespace BuberBreakfast.Domain.MenuReview.ValueObjects;

using BuberBreakfast.Domain.Common.Models;

public sealed class MenuReviewId(Guid value) : ValueObject
{
    public Guid Value { get; } = value;

    public static MenuReviewId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
