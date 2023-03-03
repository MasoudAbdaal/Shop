using System.Reflection;
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

    public async Task<User?> EditUser(User user)
    {
      User? result;
      if (user.Email != null)
        result = await GetUser(user.Email, null);
      else
        result = await GetUser(null, user.ID);

      if (result != null)
      {

        foreach (PropertyInfo item in user.GetType().GetProperties())
        {
          if (item.GetValue(user, null) != null && item.Name != "ID" && item.Name != "Email")
            result.GetType().GetProperty(item.Name)!.SetValue(result, item.GetValue(user, null), null);

        }
        _context.Users.Update(result!);
        await SaveChanges();
        return await GetUser(null, result.ID);
      }

      return default;
    }

    public async Task<User?> DeleteUser(string email)
    {
      User? u = await GetUser(email, null);
      if (u == null)
        return default;

      u!.UserInfo!.Enabled = false;
      _context.Users.Update(u);
      await SaveChanges();

      return await GetUser(email, null);
    }

    public async Task<User?> GetUser(string? email, byte[]? userId)
    {
      User? result;
      if (userId != null)
        result = await _context.Users.FindAsync(userId);
      else
        result = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

      return result == null ? default : result;
    }


    public Task SaveChanges()
    {
      return _context.SaveChangesAsync();
    }
  }
}

