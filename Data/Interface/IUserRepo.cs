using Shop.Models;

namespace Shop.Data.Interface
{

  public interface IUserRepo
  {
    Task SaveChanges();

    Task CreateUser(User user);
    Task<User?> GetUser(string email, byte[]? userId);
    Task<User?> EditUser(User user);
    Task<User?> DeleteUser(string email);
  }

}
