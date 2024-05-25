using BuberBreakfast.Domain.Common.Models;

namespace BuberBreakfast.Domain.Common.ValuesObjects;

public sealed class Rating(float value) : ValueObject
{
    public float Value { get; } = value;

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
