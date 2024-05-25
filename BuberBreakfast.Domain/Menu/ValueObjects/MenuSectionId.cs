using BuberBreakfast.Domain.Common.Models;

namespace BuberBreakfast.Domain.Menu.ValueObjects;

public sealed class MenuSectionId(Guid value) : ValueObject
{
    public Guid Value { get; } = value;

    public static MenuSectionId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
