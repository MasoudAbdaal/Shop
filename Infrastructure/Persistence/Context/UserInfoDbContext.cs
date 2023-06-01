using System.Linq.Expressions;
using Contracts.DbContext;
using Domain.Entities.User;
using Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

public class UserInfoDbContext : ModuleDbContext, IUserInfoDbContext
{
    protected override string Schema => "User_Info";

    public DbSet<UserInfo> UserInfos { get; set; }

    public UserInfoDbContext(DbContextOptions options) : base(options)
    {
        UserInfos = Set<UserInfo>();
    }

    IQueryable<UserInfo?>? IRepositoryBase<UserInfo>.GetBy<U>(Expression<Func<UserInfo, bool>> condition, bool trachChanges, Expression<Func<UserInfo, U>>? entity, Func<UserInfo, U>? orderBy)
    {
        throw new NotImplementedException();
    }
}