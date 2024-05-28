using BuberBreakfast.Domain.MenuAggregate;
using MediatR;

namespace BuberBreakfast.Application.Menus.Queries.GetAllMenus;

public record GetAllMenusQuery(Guid HostId) : IRequest<IEnumerable<Menu>>;
