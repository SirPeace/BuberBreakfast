using BuberBreakfast.Application.Common.Persistence;
using BuberBreakfast.Domain.Entities;

namespace BuberBreakfast.Infrastructure.Persistence.Repositories.UserRepositories;

public class UserInMemoryRepository : IUserRepository
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
