using Shop.Data.Interface;

namespace Shop.Data
{

  public class SQLUserRepo : IUserRepo
  {
    private readonly MainContext _context;

    public SQLUserRepo(MainContext context)
    {
      _context = context;
    }

    public Task SaveChanges()
    {
      return _context.SaveChangesAsync();
    }
  }
}