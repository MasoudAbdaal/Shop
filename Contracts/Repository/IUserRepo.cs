using Contracts.DTOs.User;
using Domain.Entities.User;

namespace Contracts.Repository;

public interface IUserRepo : IRepositoryBase<User>
{
    Task SaveChanges();

    Task<User?> GetUser(string email, byte[]? userId);
    // Task<User?> DeleteUser(string email);
    Task<User?> EditUserInfo(User user, UserModifyDTO newInfo);
}
