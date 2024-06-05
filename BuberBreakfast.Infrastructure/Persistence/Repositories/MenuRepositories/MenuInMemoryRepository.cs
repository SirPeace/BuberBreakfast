using BuberBreakfast.Application.Common.Persistence;
using BuberBreakfast.Domain.MenuAggregate;

namespace BuberBreakfast.Infrastructure.Persistence.Repositories.MenuRepositories;

public class MenuInMemoryRepository : IMenuRepository
{
    private static readonly List<Menu> Menus = [];

    public async Task Add(Menu menu)
    {
        await Task.CompletedTask;
        Menus.Add(menu);
    }

    public async Task<IEnumerable<Menu>> GetAllOfHost(Guid hostId)
    {
        await Task.CompletedTask;
        return Menus.Where(m => m.HostId.Value == hostId);
    }
}
