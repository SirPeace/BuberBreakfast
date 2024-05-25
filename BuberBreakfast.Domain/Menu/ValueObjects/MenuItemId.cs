using BuberBreakfast.Domain.Common.Models;

namespace BuberBreakfast.Domain.Menu.ValueObjects;

public sealed class MenuItemId(Guid value) : ValueObject
{
    public Guid Value { get; } = value;

    public static MenuItemId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
