using BuberBreakfast.Application.Common.Persistence;
using BuberBreakfast.Domain.HostAggregate.ValueObjects;
using BuberBreakfast.Domain.MenuAggregate;
using BuberBreakfast.Domain.MenuAggregate.Entities;
using MediatR;

namespace BuberBreakfast.Application.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandler(IMenuRepository menuRepository)
    : IRequestHandler<CreateMenuCommand, Menu>
{
    public async Task<Menu> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        var menu = Menu.Create(
            hostId: new HostId(request.HostId),
            name: request.Name,
            description: request.Description,
            sections: request.Sections.ConvertAll(section =>
                MenuSection.Create(
                    name: section.Name,
                    description: section.Description,
                    items: section.Items.ConvertAll(item =>
                        MenuItem.Create(name: item.Name, description: item.Description)
                    )
                )
            )
        );

        menuRepository.Add(menu);

        await Task.CompletedTask;
        return menu;
    }
}
