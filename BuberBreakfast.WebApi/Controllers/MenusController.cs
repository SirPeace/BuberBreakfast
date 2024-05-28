using BuberBreakfast.Application.Menus.Commands.CreateMenu;
using BuberBreakfast.Application.Menus.Queries.GetAllMenus;
using BuberBreakfast.Contracts.Menus;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.WebApi.Controllers;

[Route("hosts/{hostId:guid}/menus")]
public class MenusController(IMapper mapper, ISender mediator) : ApiController
{
    [HttpPost]
    public async Task<IActionResult> CreateMenu(Guid hostId, CreateMenuRequest requestBody)
    {
        var command = mapper.Map<CreateMenuCommand>((requestBody, hostId));
        var createdMenu = await mediator.Send(command);

        return Ok(mapper.Map<MenuResponse>(createdMenu));
    }

    [HttpGet]
    public async Task<IActionResult> GetMenus(Guid hostId)
    {
        var query = new GetAllMenusQuery(hostId);
        var menusList = await mediator.Send(query);

        return Ok(mapper.Map<IEnumerable<MenuResponse>>(menusList));
    }
}
