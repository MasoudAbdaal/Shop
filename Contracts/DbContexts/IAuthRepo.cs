using Domain.Entities.User;

namespace Contracts.DbContexts;


public interface IAuthRepo 
{
    Task SaveChanges();

    Task<User?> CreateUser(User user);
    Task<User?> GetUser(string email, byte[]? userId);

    Task<User?> EditEmail(User user, string newEmail);
    // Task<User?> EditPhone(User user, string newPhone);
}
