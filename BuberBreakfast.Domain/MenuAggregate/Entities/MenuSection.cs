using BuberBreakfast.Domain.Common.Models;
using BuberBreakfast.Domain.MenuAggregate.ValueObjects;

namespace BuberBreakfast.Domain.MenuAggregate.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items = [];

    public required string Name { get; init; }
    public required string Description { get; init; }
    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    private MenuSection(MenuSectionId id)
        : base(id) { }

    public static MenuSection Create(string name, string description) =>
        new MenuSection(MenuSectionId.CreateUnique()) { Name = name, Description = description };
}
