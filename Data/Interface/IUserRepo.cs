using Shop.Models;

namespace Shop.Data.Interface
{

  public interface IUserRepo
  {
    Task SaveChanges();

    Task<User?> EditUser(User user);
    Task<User?> DeleteUser(string email);
  }

}
