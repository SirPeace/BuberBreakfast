namespace BuberBreakfast.Application.Common.Interfaces;

public interface IJwtTokenGenerator
{
    public string GenerateToken(Guid userId, string firstName, string lastName);
}
