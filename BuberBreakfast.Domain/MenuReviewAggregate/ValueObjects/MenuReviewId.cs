using BuberBreakfast.Domain.Common.Models;

namespace BuberBreakfast.Domain.MenuReviewAggregate.ValueObjects;

public sealed class MenuReviewId(Guid value) : ValueObject
{
    public Guid Value { get; } = value;

    public static MenuReviewId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
