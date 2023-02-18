using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shop.Data.Interface;
using Shop.Models;

namespace Shop.Data
{

  public class UserRepo : IUserRepo
  {
    private readonly MainContext _context;

    public UserRepo(MainContext context)
    {
      _context = context;
    }

    public Task SaveChanges()
    {
      return _context.SaveChangesAsync();
    }

    public async Task<User?> CreateUser(User user)
    {
      User? u = await GetUser(user.Email, null);

      if (u == null)
      {
        await _context.Users.AddAsync(user!);
        await SaveChanges();
        return await _context.Users.FindAsync(user?.ID);
      }

      return u;
    }


    public async Task<User?> GetUser(string email, byte[]? userId)
    {
      User? result;
      if (userId != null)
        result = await _context.Users.FindAsync(userId);
      else
        result = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

      return result == null ? default : result;
    }

    public async Task<User> EditUser(User user)
    {
      User? u = await GetUser(user.Email, null);

      EntityEntry<User> result = _context.Users.Update(user!);
      await _context.SaveChangesAsync();

      return result.Entity;
    }

    public async Task DeleteUser(string email)
    {
      User? u = await GetUser(email, null);
      if (u == null)
        return;

      (u.UserInfo!.Enabled) = false;
    }
  }





}
