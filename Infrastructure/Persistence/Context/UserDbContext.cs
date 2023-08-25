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
    //TODO:
    //1. Remove Schema Property and set it as defailt in Base Class
    //2. remove userInfoDbContext (LESS Dependency!!)
    public DbSet<User>? Users { get; set; }


    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) => Users = Set<User>();

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => base.SaveChangesAsync(cancellationToken);

    public async Task<bool> Exist(string email, byte[]? userId)
    {
        if (email is not null)
            return await Users!.AnyAsync(x => x.Email == email);

        if (userId is not null)
            return await Users!.AnyAsync(x => x.ID == userId);

        throw new InvalidDataException();
    }

    public async Task<User?> GetUser(string? email, byte[]? userId)
    {
        IQueryable<User> query = Users!;

        if (userId is not null)
            query = query.Include(u => u.UserInfo)
                         .Where(u => u.ID == userId);

        if (email is not null)
            query = query.Include(u => u.UserInfo)
                         .Where(u => u.Email == email);

        return await query.FirstAsync();
    }

    public async Task<User?> CreateUser(User user)
    {
        await AddAsync(user);
        await SaveChangesAsync();
        return await GetUser(user.Email, null);
    }

    public async Task<User?> GetUserWithInfo(string email, byte[]? userId)
    {
        IQueryable<User> query = Users!;

        if (userId is not null)
            query = query.Where(x => x.ID == userId);
        if (email is not null)
            query = query.Where(x => x.Email == email);

        return await query.Include(x => x.UserInfo).FirstAsync();

    }


    // public async Task<User?> EditUserInfo(User user, UserModifyDTO newInfo)
    // {

    //     user!.Name = newInfo.Name.Length > 5 ? newInfo.Name : user.Name;

    //     UserInfo Info = _userInfoDbContext!.UserInfos!.Find(user.ID)!;
    //     if (user != null)
    //     {
    //         // Info = GeneralUtil.ApplyChanges(Info, _mapper!.Map<UserInfoDTO, UserInfo>(newInfo.info!))!;
    //         if (Info is not null)
    //         {
    //             _userInfoDbContext.UserInfos.Update(Info!);
    //             Users!.Update(user!);

    //             await SaveChangesAsync();
    //             return user;
    //         }
    //         return default;
    //     }

    //     return default;
    // }



    // public async Task<User?> EditEmail(User user, string newEmail)
    // {
    //     user.Email = newEmail;

    //     Users!.Update(user);
    //     await SaveChangesAsync();
    //     return await GetUser(newEmail, null);
    // }

    // public Task<User?> DeleteUser(string email)
    // {
    //     throw new NotImplementedException();
    // }

}
