using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Contracts.DbContexts;

public interface IUserInfoDbContext
{
    DbSet<UserInfo>? UserInfos { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}