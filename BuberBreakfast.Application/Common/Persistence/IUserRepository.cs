using BuberBreakfast.Domain.Entities;

namespace BuberBreakfast.Application.Common.Persistence;

public interface IUserRepository
{
    public User? GetUserByEmail(string email);
    public void Add(User user);
}
