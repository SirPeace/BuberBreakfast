using BuberBreakfast.Domain.MenuAggregate;
using MediatR;

namespace BuberBreakfast.Application.Menus.Commands.CreateMenu;

public record CreateMenuCommand(
    Guid HostId,
    string Name,
    string Description,
    List<CreateMenuCommandMenuSection> Sections
) : IRequest<Menu>;

public record CreateMenuCommandMenuSection(
    string Name,
    string Description,
    List<CreateMenuCommandMenuItem> Items
);

public record CreateMenuCommandMenuItem(string Name, string Description);
