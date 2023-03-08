using System.Reflection;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shop.Data.Interface;
using Shop.DTOs;
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

    public async Task<User?> EditUserInfo(User user, UserModifyDTO newInfo)
    {

      user!.Name = newInfo.Mail.Length > 5 ? newInfo.Mail : user.Name;

      UserInfo Info = _context.User_Info.Find(user.ID)!;

      if (user != null)
      {

        foreach (PropertyInfo item in newInfo.info!.GetType().GetProperties())
        {
          var value = item.GetValue(newInfo.info, null);

          if (value != null && value!.GetType().FullName != "System.Byte[]")
            Info!.GetType().GetProperty(item.Name)!.SetValue(Info, item.GetValue(newInfo.info, null));

        }

        _context.User_Info.Update(Info!);
        _context.Users.Update(user!);

        await SaveChanges();
        return user;
      }

      return default;
    }


    // public async Task<User?> DeleteUser(string email)
    // {
    //   User? u = await GetUser(email, null);
    //   if (u == null)
    //     return default;

    //   u!.UserInfo!.Enabled = false;
    //   _context.Users.Update(u);
    //   await SaveChanges();

    //   return await GetUser(email, null);
    // }

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

