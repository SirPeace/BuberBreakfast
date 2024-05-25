namespace BuberBreakfast.Domain.Host.ValueObjects;

using BuberBreakfast.Domain.Common.Models;

public sealed class HostId(Guid value) : ValueObject
{
    public Guid Value { get; } = value;

    public static HostId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
