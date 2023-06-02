using System.Linq.Expressions;
using AutoMapper;
using Contracts.DbContext;
using Contracts.DTOs.User;
using Domain.Entities.User;
using Infrastructure;
using Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

internal sealed class UserDbContext : ModuleDbContext, IUserDbContext
{
    protected override string Schema => "Shop";

    public DbSet<User>? Users { get; set; }
    private IUserInfoDbContext? _userInfoDbContext { get; set; }

    private readonly IMapper? _mapper;

    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {

    }


    public UserDbContext(DbContextOptions<UserDbContext> options, IMapper mapper, IUserInfoDbContext userInfoDbContext) : base(options)
    {
        Users = Set<User>();
        _mapper = mapper;
        _userInfoDbContext = userInfoDbContext;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }


    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await this.SaveChangesAsync(cancellationToken) + await _userInfoDbContext!.SaveChangesAsync(cancellationToken);
    }

    public async Task<User?> EditUserInfo(User user, UserModifyDTO newInfo)
    {

        user!.Name = newInfo.Name.Length > 5 ? newInfo.Name : user.Name;

        UserInfo Info = _userInfoDbContext!.UserInfos.Find(user.ID)!;
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
            await base.SaveChangesAsync();
            return await GetUser(user.Email, null);
        }
        else
            return u;
    }

    public async Task<User?> EditEmail(User user, string newEmail)
    {
        user.Email = newEmail;

        Users!.Update(user);
        await base.SaveChangesAsync();
        return await GetUser(newEmail, null);
    }

    Task<User?> IUserDbContext.DeleteUser(string email)
    {
        throw new NotImplementedException();
    }

    Task<User?> IUserDbContext.EditUserInfo(User user, UserModifyDTO newInfo)
    {
        throw new NotImplementedException();
    }

}