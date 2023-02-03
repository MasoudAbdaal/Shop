using Shop.Models;

namespace Shop.Data
{

  public class SQLUserRepo : IUserRepo
  {
    private readonly UserContext _context;

    public SQLUserRepo(UserContext context)
    {
      _context = context;
    }

    public Task SaveChanges()
    {
      return _context.SaveChangesAsync();
    }
  }
}