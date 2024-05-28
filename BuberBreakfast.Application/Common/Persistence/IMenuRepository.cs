using BuberBreakfast.Domain.MenuAggregate;

namespace BuberBreakfast.Application.Common.Persistence;

public interface IMenuRepository
{
    public void Add(Menu menu);
    public IEnumerable<Menu> GetAllOfHost(Guid hostId);
}
