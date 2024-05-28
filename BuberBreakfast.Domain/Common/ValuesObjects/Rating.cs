using BuberBreakfast.Domain.Common.Models;

namespace BuberBreakfast.Domain.Common.ValuesObjects;

public sealed class Rating(double value) : ValueObject
{
    public double Value { get; } = value;

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static explicit operator double(Rating rating) => rating.Value;
}
