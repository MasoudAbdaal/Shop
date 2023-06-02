using Contracts.DbContext;
using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Contracts.DbContext;

public interface IUserInfoDbContext : IRepositoryBase<UserInfo>
{
    DbSet<UserInfo> UserInfos { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}