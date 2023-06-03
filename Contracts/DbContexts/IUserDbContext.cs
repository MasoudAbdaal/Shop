using Contracts.DTOs.User;
using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Contracts.DbContexts;

public interface IUserDbContext
{
    DbSet<User>? Users { get; set; }

    Task<User?> CreateUser(User user);
    Task<User?> GetUser(string email, byte[]? userId);
    Task<User?> EditEmail(User user, string newEmail);
    Task<User?> DeleteUser(string email);
    Task<User?> EditUserInfo(User user, UserModifyDTO newInfo);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
