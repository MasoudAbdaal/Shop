using System.Linq.Expressions;
using AutoMapper;
using Contracts.DbContext;
using Contracts.DTOs.User;
using Domain.Entities.User;
using Infrastructure;
using Infrastructure.Common;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

internal sealed class UserDbContext : ModuleDbContext, IUserRepo
{
    protected override string Schema => "User";

    public DbSet<User> Users { get; set; }
    private IUserInfoDbContext _userInfoDbContext { get; set; }

    private readonly IMapper _mapper;

    public UserDbContext(DbContextOptions options, IMapper mapper, IUserInfoDbContext userInfoDbContext) : base(options)
    {
        Users = Set<User>();
        _mapper = mapper;
        _userInfoDbContext = userInfoDbContext;
    }


    public async Task<User?> EditUserInfo(User user, UserModifyDTO newInfo)
    {

        user!.Name = newInfo.Name.Length > 5 ? newInfo.Name : user.Name;

        UserInfo Info = _userInfoDbContext.UserInfos.Find(user.ID)!;
        if (user != null)
        {
            Info = GeneralUtil.ApplyChanges(Info, _mapper.Map<UserInfoDTO, UserInfo>(newInfo.info!))!;
            if (Info is not null)
            {
                _userInfoDbContext.UserInfos.Update(Info!);
                Users!.Update(user!);

                await SaveChangesAsync();
                return user;
            }
            return default;
        }

        return default;
    }

    public async Task<User?> GetUser(string? email, byte[]? userId)
    {
        User? result;
        if (userId != null)
            result = await Users!.FindAsync(userId);
        else
            result = await Users!.FirstOrDefaultAsync(x => x.Email == email);

        return result == null ? default : result;
    }

    IQueryable<User?>? IRepositoryBase<User>.GetBy<U>(Expression<Func<User, bool>> condition, bool trachChanges, Expression<Func<User, U>>? entity, Func<User, U>? orderBy)
    {
        throw new NotImplementedException();
    }
}