using BuberBreakfast.Application.Menus.Commands.CreateMenu;
using BuberBreakfast.Contracts.Menus;
using BuberBreakfast.Domain.MenuAggregate;
using Mapster;

namespace BuberBreakfast.WebApi.Mappings;

class MenuMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config
            .NewConfig<(CreateMenuRequest RequestBody, Guid HostId), CreateMenuCommand>()
            .Map(dest => dest.HostId, src => src.HostId)
            .Map(dest => dest, src => src.RequestBody);

        config.NewConfig<Menu, MenuResponse>().Map(dest => dest, src => src);
    }
}
