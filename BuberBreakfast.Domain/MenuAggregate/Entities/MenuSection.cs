using BuberBreakfast.Domain.Common.Models;
using BuberBreakfast.Domain.MenuAggregate.ValueObjects;

namespace BuberBreakfast.Domain.MenuAggregate.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    public required string Name { get; init; }
    public required string Description { get; init; }

    private List<MenuItem> _items = [];
    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    private MenuSection(MenuSectionId id)
        : base(id) { }

    public static MenuSection Create(
        string name,
        string description,
        List<MenuItem>? items = null
    ) =>
        new MenuSection(MenuSectionId.CreateUnique())
        {
            Name = name,
            Description = description,
            _items = items ?? []
        };
}
