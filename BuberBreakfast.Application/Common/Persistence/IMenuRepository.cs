using BuberBreakfast.Domain.MenuAggregate;

namespace BuberBreakfast.Application.Common.Persistence;

public interface IMenuRepository
{
    public Task Add(Menu menu);
    public Task<IEnumerable<Menu>> GetAllOfHost(Guid hostId);
}
