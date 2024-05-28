using BuberBreakfast.Application.Common.Persistence;
using BuberBreakfast.Domain.MenuAggregate;
using MediatR;

namespace BuberBreakfast.Application.Menus.Queries.GetAllMenus;

public class GetAllMenusQueryHandler(IMenuRepository menuRepository)
    : IRequestHandler<GetAllMenusQuery, IEnumerable<Menu>>
{
    public async Task<IEnumerable<Menu>> Handle(
        GetAllMenusQuery request,
        CancellationToken cancellationToken
    )
    {
        await Task.CompletedTask;
        var allMenus = menuRepository.GetAllOfHost(request.HostId);

        return allMenus;
    }
}
