using BuberBreakfast.Application.Common.Persistence;
using BuberBreakfast.Domain.MenuAggregate;

namespace BuberBreakfast.Infrastructure.Persistence;

public class MenuRepository : IMenuRepository
{
    private static readonly List<Menu> _menus = [];

    public void Add(Menu menu) => _menus.Add(menu);

    public IEnumerable<Menu> GetAllOfHost(Guid hostId) =>
        _menus.Where(m => m.HostId.Value == hostId);
}
