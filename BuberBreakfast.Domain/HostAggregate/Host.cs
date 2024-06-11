using BuberBreakfast.Domain.Common.Models;
using BuberBreakfast.Domain.HostAggregate.ValueObjects;
using BuberBreakfast.Domain.MenuAggregate.ValueObjects;

namespace BuberBreakfast.Domain.HostAggregate;

public class Host(HostId id) : AggregateRoot<HostId>(id)
{
    private List<MenuId> _menuIds = [];
    public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();
}
