using BuberBreakfast.Application.Authentication.Commands.Register;
using BuberBreakfast.Application.Authentication.Common;
using BuberBreakfast.Application.Authentication.Queries.Login;
using BuberBreakfast.Contracts.Authentication;
using Mapster;

namespace BuberBreakfast.WebApi.Mappings;

class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config
            .NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest, src => src.User);

        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<RegisterRequest, RegisterCommand>();
    }
}
