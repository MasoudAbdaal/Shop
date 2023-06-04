using System.Linq.Expressions;
using Contracts.DbContexts;
using Domain.Entities.User;
using Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context;

internal sealed class UserInfoDbContext : ModuleDbContext, IUserInfoDbContext
{
    protected override string Schema => "Shop";
    public DbSet<UserInfo>? UserInfos { get; set; }


    public UserInfoDbContext(DbContextOptions<UserInfoDbContext> options) : base(options)
    {
        UserInfos = Set<UserInfo>();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}