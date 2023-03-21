using Shop.Models;

namespace Shop.Data.Repository.Contracts
{

  public interface IAuthRepo : IRepositoryBase<User>
  {
    Task SaveChanges();

    Task<User?> CreateUser(User user);
    Task<User?> GetUser(string email, byte[]? userId);

    Task<User?> EditEmail(User user, string newEmail);
    // Task<User?> EditPhone(User user, string newPhone);
  }

}
