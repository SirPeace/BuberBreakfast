using BuberBreakfast.Domain.Common.Models;

namespace BuberBreakfast.Domain.BreakfastAggregate.ValueObjects;

public sealed class BreakfastId(Guid value) : ValueObject
{
    public Guid Value { get; } = value;

    public static BreakfastId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
