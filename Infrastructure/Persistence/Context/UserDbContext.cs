using AutoMapper;
using Contracts.DbContexts;
using Contracts.DTOs.User;
using Domain.Entities.User;
using Infrastructure;
using Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context;

internal sealed class UserDbContext : ModuleDbContext, IUserDbContext
{
    protected override string Schema => "Shop";
    public DbSet<User>? Users { get; set; }

    private IUserInfoDbContext? _userInfoDbContext { get; set; }
    private readonly IMapper? _mapper;


    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
        Users = Set<User>();
    }

    public UserDbContext(DbContextOptions<UserDbContext> options, IMapper mapper, IUserInfoDbContext userInfoDbContext) : base(options)
    {
        _mapper = mapper;
        _userInfoDbContext = userInfoDbContext;
    }


    public new async Task<(int userDbContextResult, int userInfoDbContextResult)> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        Task<int>[] tasks = new Task<int>[] { base.SaveChangesAsync(cancellationToken), _userInfoDbContext!.SaveChangesAsync(cancellationToken) };
        await Task.WhenAll(tasks);

        return (tasks[0].Result, tasks[1].Result);
    }

    public async Task<User?> EditUserInfo(User user, UserModifyDTO newInfo)
    {

        user!.Name = newInfo.Name.Length > 5 ? newInfo.Name : user.Name;

        UserInfo Info = _userInfoDbContext!.UserInfos!.Find(user.ID)!;
        if (user != null)
        {
            Info = GeneralUtil.ApplyChanges(Info, _mapper!.Map<UserInfoDTO, UserInfo>(newInfo.info!))!;
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

    public async Task<User?> CreateUser(User user)
    {
        User? u = await GetUser(user.Email, null);

        if (u == null)
        {
            await AddAsync(user!);
            await SaveChangesAsync();
            return await GetUser(user.Email, null);
        }
        else
            return u;
    }

    public async Task<User?> EditEmail(User user, string newEmail)
    {
        user.Email = newEmail;

        Users!.Update(user);
        await SaveChangesAsync();
        return await GetUser(newEmail, null);
    }

    public Task<User?> DeleteUser(string email)
    {
        throw new NotImplementedException();
    }
}