using BuberBreakfast.Application.Common.Persistence;
using BuberBreakfast.Domain.MenuAggregate;
using Microsoft.EntityFrameworkCore;

namespace BuberBreakfast.Infrastructure.Persistence.Repositories.MenuRepositories;

public class MenuEFRepository(BuberBreakfastDbContext dbContext) : IMenuRepository
{
    public async Task Add(Menu menu)
    {
        await dbContext.Menus.AddAsync(menu);
        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Menu>> GetAllOfHost(Guid hostId)
    {
        return await dbContext.Menus.Where(m => m.HostId.Value == hostId).ToListAsync();
    }
}
