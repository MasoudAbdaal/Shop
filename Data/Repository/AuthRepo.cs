using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shop.Data.Repository.Contracts;
using Shop.Models;

namespace Shop.Data
{

  internal sealed class AuthRepo : RepositoryBase<User>, IAuthRepo
  {

    public AuthRepo(MainContext context) : base(context)
    {

    }

    public Task SaveChanges()
    {
      return MainContext.SaveChangesAsync();
    }


    public async Task<User?> CreateUser(User user)
    {
      User? u = await GetUser(user.Email, null);

      if (u == null)
      {
        await MainContext.Users!.AddAsync(user!);
        await SaveChanges();
        return await GetUser(user.Email, null);
      }
      else
        return u;
    }


    public async Task<User?> GetUser(string? email, byte[]? userId)
    {
      User? result;
      if (userId != null)
        result = await MainContext.Users!.FindAsync(userId);
      else
        result = await MainContext.Users!.FirstOrDefaultAsync(x => x.Email == email);

      return result == null ? default : result;
    }

    public async Task<User?> EditEmail(User user, string newEmail)
    {
      user.Email = newEmail;

      MainContext.Update(user);
      await SaveChanges();
      return await GetUser(newEmail, null);
    }


    //   public async Task<User?> EditPhone(User user, string newPhone)
    //   {
    //     user.UserInfo!.PhoneNumber = newPhone;

    //     _context.Update(user);
    //     await SaveChanges();

    //     return await GetUser(user.Email, null);
    //   }
  }
}





