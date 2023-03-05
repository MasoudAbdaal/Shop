using Shop.DTOs;
using Shop.Models;

namespace Shop.Data.Interface
{

  public interface IUserRepo
  {
    Task SaveChanges();

    Task<User?> GetUser(string email, byte[]? userId);
    Task<User?> EditUserInfo(User user, UserModifyDTO newInfo);
    Task<User?> DeleteUser(string email);
  }

}
