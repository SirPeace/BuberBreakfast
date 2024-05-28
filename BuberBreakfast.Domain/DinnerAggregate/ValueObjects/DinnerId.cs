namespace BuberBreakfast.Domain.Dinner.ValueObjects;

using BuberBreakfast.Domain.Common.Models;

public sealed class DinnerId(Guid value) : ValueObject
{
    public Guid Value { get; } = value;

    public static DinnerId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
