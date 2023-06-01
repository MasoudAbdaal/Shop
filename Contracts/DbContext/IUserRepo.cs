using Contracts.DTOs.User;
using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Contracts.DbContext;

public interface IUserRepo : IRepositoryBase<User>
{
     DbSet<User> Users { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    Task<User?> GetUser(string email, byte[]? userId);
    // Task<User?> DeleteUser(string email);
    Task<User?> EditUserInfo(User user, UserModifyDTO newInfo);
}
