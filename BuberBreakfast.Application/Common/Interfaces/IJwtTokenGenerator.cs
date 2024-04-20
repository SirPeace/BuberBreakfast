using BuberBreakfast.Domain.Entities;

namespace BuberBreakfast.Application.Common.Interfaces;

public interface IJwtTokenGenerator
{
    public string GenerateToken(User user);
}
