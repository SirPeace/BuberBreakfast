using BuberBreakfast.Domain.Common.Models;
using BuberBreakfast.Domain.Menu.ValueObjects;

namespace BuberBreakfast.Domain.Menu.Entities;

public sealed class MenuItem : Entity<MenuItemId>
{
    public required string Name { get; init; }
    public required string Description { get; init; }

    private MenuItem(MenuItemId id)
        : base(id) { }

    public static MenuItem Create(string name, string description) =>
        new MenuItem(MenuItemId.CreateUnique()) { Name = name, Description = description };
}
