using BuberBreakfast.Application.Common.Persistence;
using BuberBreakfast.Domain.Entities;

namespace BuberBreakfast.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> Users = [];

    public User? GetUserByEmail(string email)
    {
        return Users.Find(u => u.Email == email);
    }

    public void Add(User user)
    {
        Users.Add(user);
    }
}